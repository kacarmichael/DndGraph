using System.Text;
using Dnd.API.Main.Extensions;
using Dnd.Application.Auth.Models;
using Dnd.Application.Caching;
using Dnd.Application.Logging;
using Dnd.Application.Main.Infrastructure;
using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Characters.Stats;
using Dnd.Application.Main.Models.Rolls;
using Dnd.Application.Main.Repositories;
using Dnd.Application.Main.Serializers;
using Dnd.Application.Main.Services;
using Dnd.Core.Caching;
using Dnd.Core.Logging;
using Dnd.Core.Main.Models.Characters.Stats;
using Dnd.Core.Main.Models.Rolls;
using Dnd.Core.Main.Repositories;
using Dnd.Core.Main.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Dnd.API.Auth", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new AbilitySerializer());
        options.JsonSerializerOptions.Converters.Add(new SkillSerializer());
        options.JsonSerializerOptions.Converters.Add(new AbilityBlockSerializer());
        options.JsonSerializerOptions.Converters.Add(new SkillBlockSerializer());
    });

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddDbContext<CharacterDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));

builder.Services.AddDbContext<RollDbContext>(options =>
    options.UseInMemoryDatabase("RollDb"));

builder.Services.AddTransient<ICharacterRepository, CharacterRepository<Character>>();
builder.Services.AddTransient<ICharacterService, CharacterService>(); //<>()
builder.Services.AddTransient<IRollRepository, RollRepository<DiceRollBase>>();
builder.Services.AddTransient<IRollMapperService, RollMapperService>();
builder.Services.AddTransient<IRollService, RollService>();
builder.Services.AddTransient<IClassMapperService, ClassMapperService>();
builder.Services.AddTransient<IDiceSimulationFactory, DiceSimulationFactory>();
builder.Services.AddTransient<IDiceRollCache, DiceRollCache>();
builder.Services.AddTransient<IDiceSimulationCache, DiceSimulationCache>();
builder.Services.AddTransient<IAbilityBlock, AbilityBlock>();
builder.Services.AddTransient<ISkillBlock, SkillBlock>();

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
//builder.Services.Configure<JwksSettings>(builder.Configuration.GetSection("Jwks"));

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowLocalhost",
            builder =>
            {
                builder.WithOrigins("http://localhost:3002", "https://localhost:3002")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
    }
);

// string secret = builder.Configuration["Jwt:Secret"];
// if (string.IsNullOrEmpty(secret))
// {
//     throw new Exception("Secret is null or empty");
//     
// }

// builder.Services.AddAuthentication(options =>
//     {
//         options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//         options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//     })
//     .AddJwtBearer(options =>
//     {
//         options.Challenge = "Bearer";
//         options.UseSecurityTokenValidators = true;
//         options.RequireHttpsMetadata = false;
//         options.SaveToken = true;
//         options.TokenValidationParameters = new TokenValidationParameters
//         {
//             ValidateIssuer = true,
//             ValidIssuer = builder.Configuration["Jwt:Issuer"],
//             ValidateAudience = true,
//             ValidAudience = builder.Configuration["Jwt:Audience"],
//             ValidateLifetime = true,
//             ClockSkew = TimeSpan.Zero,
//             ValidateIssuerSigningKey = true,
//             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"])),
//             ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha256 }
//         };
//
//         options.Events = new JwtBearerEvents
//         {
//             OnTokenValidated = context =>
//             {
//                 Console.WriteLine("Begin Token Validation");
//                 Console.WriteLine(context.SecurityToken.ToString());
//                 if (context.Principal.Identity.IsAuthenticated)
//                 {
//                     Console.WriteLine("Token Validated");
//                     var ticket = new AuthenticationTicket(context.Principal, "Bearer");
//                     return Task.FromResult(AuthenticateResult.Success(ticket));
//                 }
//                 else
//                 {
//                     Console.WriteLine("Token Not Validated");
//                     return Task.FromResult(AuthenticateResult.Fail("Token Not Validated"));
//                 }
//                 //Console.WriteLine($"Context: {JsonConvert.SerializeObject(context)}");
//                 return Task.CompletedTask;
//             },
//             OnAuthenticationFailed = context =>
//             {
//                 Console.WriteLine("Token Validation Failed");
//                 Console.WriteLine(context.Exception.Message);
//                 return Task.CompletedTask;
//             },
//             OnChallenge = context =>
//             {
//                 Console.WriteLine("Auth Challenge");
//                 Console.WriteLine(context.Error);
//                 Console.WriteLine(context.ErrorDescription);
//                 //Console.WriteLine($"Context: {JsonConvert.SerializeObject(context)}");
//                 return Task.CompletedTask;
//             },
//             OnForbidden = context =>
//             {
//                 Console.WriteLine("Auth Forbidden");
//                 Console.WriteLine(context.HttpContext.User.Claims);
//                 Console.WriteLine(context.HttpContext.Request.Path);
//                 return Task.CompletedTask;
//             }
//         };
//     });

// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options =>
//     {
//         options.TokenValidationParameters = new TokenValidationParameters
//         {
//             ValidateIssuer = true,
//             ValidIssuer = builder.Configuration["Jwt:Issuer"],
//             ValidateAudience = true,
//             ValidAudience = builder.Configuration["Jwt:Audience"],
//             ValidateLifetime = true,
//             ClockSkew = TimeSpan.Zero,
//             ValidateIssuerSigningKey = true,
//             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"])),
//             // ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha256 }
//         };
//     });

// builder.Services.AddLogging(logging =>
// {
//     logging.AddConsole();
//     logging.AddDebug();
// });

// builder.Services.AddLogging(logging =>
// {
//     logging.AddProvider(new DndLoggerProvider("Dnd.API.Main",
//             new ConsoleLoggerProvider(
//                 builder.Services.BuildServiceProvider()
//                     .GetRequiredService<IOptionsMonitor<ConsoleLoggerOptions>>()
//             )
//         )
//     );
// });

builder.Services.AddSingleton<ILoggingClient>(
    new LoggingClient(new LoggerConfig("Dnd.API.Main", null, LogLevel.Information)));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowLocalhost");
app.UseHttpsRedirection();
app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();
app.MapControllers();

app.Services.SaveSwaggerJson();
app.UseSwagger();
app.UseSwaggerUI();


// using (var scope = app.Services.CreateScope())
// {
// var dbContext = scope.ServiceProvider.GetService<CharacterDbContext>();
// dbContext.Database.EnsureCreated();
// dbContext.Populate();
// }


app.Run();