using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddDbContext<CharacterDbContext>(options =>
    options.UseInMemoryDatabase("RollDb"));

builder.Services.AddDbContext<RollDbContext>(options =>
    options.UseInMemoryDatabase("RollDb"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICharacterRepository, CharacterRepository<Character>>();
builder.Services.AddTransient<ICharacterService, CharacterService>(); //<>()
builder.Services.AddTransient<IRollRepository, RollRepository<DiceRollBase>>();
builder.Services.AddTransient<IRollMapperService, RollMapperService>();
builder.Services.AddTransient<IRollService, RollService>();
builder.Services.AddTransient<IClassMapperService, ClassMapperService>();
builder.Services.AddTransient<IDiceSimulationFactory, DiceSimulationFactory>();

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowLocalhost",
            builder =>
            {
                builder.WithOrigins("http://localhost:3002", "https://localhost:3002").AllowAnyHeader()
                    .AllowAnyMethod();
            });
    }
);

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };

        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                Console.WriteLine("Token Validation Successful");
                Console.WriteLine(context.SecurityToken.ToString());
                return Task.CompletedTask;
            },
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine("Token Validation Failed");
                Console.WriteLine(context.Exception.Message);
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.AddDebug();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.Services.SaveSwaggerJson();

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

// using (var scope = app.Services.CreateScope())
// {
// var dbContext = scope.ServiceProvider.GetService<CharacterDbContext>();
// dbContext.Database.EnsureCreated();
// dbContext.Populate();
// }

app.UseCors("AllowLocalhost");

app.Run();