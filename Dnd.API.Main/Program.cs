using Dnd.API.Main.Extensions;
using Dnd.Application.Auth.Models;
using Dnd.Application.Logging.Implementations;
using Dnd.Application.Logging.Interfaces;
using Dnd.Application.Main.Caching.Implementations;
using Dnd.Application.Main.Caching.Interfaces;
using Dnd.Application.Main.Infrastructure;
using Dnd.Application.Main.Models.Campaigns;
using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Characters.Stats;
using Dnd.Application.Main.Models.Intermediate;
using Dnd.Application.Main.Models.Rolls;
using Dnd.Application.Main.Models.Simulations;
using Dnd.Application.Main.Models.Users;
using Dnd.Application.Main.Repositories.Implementations;
using Dnd.Application.Main.Repositories.Interfaces;
using Dnd.Application.Main.Services.Implementations;
using Dnd.Application.Main.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
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
builder.Services.AddControllers();
// .AddJsonOptions(options =>
// {
//     options.JsonSerializerOptions.Converters.Add(new AbilitySerializer());
//     options.JsonSerializerOptions.Converters.Add(new SkillSerializer());
//     options.JsonSerializerOptions.Converters.Add(new AbilityBlockSerializer());
//     options.JsonSerializerOptions.Converters.Add(new SkillBlockSerializer());
//     options.JsonSerializerOptions.Converters.Add(new CharacterStatsSerializer());
//     options.JsonSerializerOptions.Converters.Add(new CharacterSerializer());
// });

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddDbContext<DndDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));

// builder.Services.AddDbContext<RollDbContext>(options =>
//     options.UseInMemoryDatabase("RollDb"));

builder.Services.AddTransient<ICampaignRepository<Campaign>, CampaignRepository>();
builder.Services.AddTransient<ICampaignSessionRepository<CampaignSession>, CampaignSessionRepository>();
builder.Services.AddTransient<ICharacterRepository<Character, CharacterStats, CharacterClass>, CharacterRepository>();
builder.Services.AddTransient<IRollRepository<DiceRollBase>, RollRepository>();
builder.Services.AddTransient<IUserRepository<DomainUser>, UserRepository>(); 

builder.Services.AddTransient<IDiceSimulationFactory, DiceSimulationFactory>();
builder.Services.AddTransient<IDiceRollCache, DiceRollCache>();
builder.Services.AddTransient<IDiceSimulationCache, DiceSimulationCache>();
builder.Services.AddTransient<IClassMapperService, ClassMapperService>();


builder.Services.AddTransient<ICampaignService, CampaignService>();
builder.Services.AddTransient<ICharacterService, CharacterService>(); //<>()
builder.Services.AddTransient<IRollMapperService, RollMapperService>();


builder.Services.AddTransient<IRollService, RollService>();
builder.Services.AddTransient<IUserService, UserService>();





// builder.Services.AddTransient<IAbilityBlock, AbilityBlock>();
// builder.Services.AddTransient<ISkillBlock, SkillBlock>();

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
//     var dbContext = scope.ServiceProvider.GetService<DndDbContext>();
//     //dbContext.Database.Migrate();
//     var stat_block = new CharacterStats(
//         id: 1,
//         characterId: 1,
//         level: 7,
//         new AbilityBlock(
//             new List<int> { 10, 13, 12, 17, 19, 18 }
//         )
//     );
//     var cc = new List<CharacterClass>
//     {
//         new CharacterClass(
//             classId: 11,
//             characterId: 1,
//             levels: 6),
//         new CharacterClass(
//             classId: 12,
//             characterId: 1,
//             levels: 1)
//     };
//     var test_char = new Character(
//         id: 1,
//         name: "Theodred Venran",
//         stats: stat_block,
//         charClass: cc,
//         userId: 1);
//     dbContext.Characters.Add(test_char);
//     dbContext.CharacterStats.Add(stat_block);
//     dbContext.CharacterClasses.AddRange(cc.Select(cc => (CharacterClass)cc));
//     dbContext.SaveChanges();
// }

using (var scope = app.Services.CreateScope())
{
    var characterService = scope.ServiceProvider.GetService<ICharacterService>();
    var userService = scope.ServiceProvider.GetService<IUserService>();
    await userService.AddUserAsync(new DomainUser(
        id: 1,
        username: "admin"));
    await characterService.AddCharacterAsync(
        new Character()
        {
            Id = 1,
            Name = "Theodred Venran",
            Stats = new CharacterStats(
                id: 1,
                characterId: 1,
                level: 7,
                new AbilityBlock(
                    new List<int> { 10, 13, 12, 17, 19, 18 }
                )),
            UserId = 1,
            Classes = new List<CharacterClass>
            {
                new CharacterClass(
                    classId: 11,
                    characterId: 1,
                    levels: 6),
                new CharacterClass(
                    classId: 12,
                    characterId: 1,
                    levels: 1)
            },
            
        });
}


// using (var scope = app.Services.CreateScope())
// {
// var dbContext = scope.ServiceProvider.GetService<DndDbContext>();
// dbContext.Database.EnsureCreated();
// dbContext.Populate();
// }


app.Run();