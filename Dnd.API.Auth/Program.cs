using Dnd.Application.Abstractions;
using Dnd.Application.Auth.Infrastructure.Database;
using Dnd.Application.Auth.Models;
using Dnd.Application.Auth.Repositories;
using Dnd.Application.Auth.Services;
using Dnd.Application.Logging;
using Dnd.Application.Main.Repositories;
using Dnd.Application.Main.Services;
using Dnd.Core.Abstractions;
using Dnd.Core.Auth.Repositories;
using Dnd.Core.Auth.Services;
using Dnd.Core.Logging;
using Dnd.Core.Main.Repositories;
using Dnd.Core.Main.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dnd.API.Auth", Version = "v1" });
});

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddDbContext<UserDbContext>(options => options.UseInMemoryDatabase("UserDb"));
builder.Services.AddOpenApi();

// builder.Services.AddLogging(logging =>
// {
//     logging.AddProvider(new AuthLoggerProvider("Dnd.API.Auth",
//         new ConsoleLoggerProvider(
//             builder.Services.BuildServiceProvider()
//                 .GetRequiredService<IOptionsMonitor<ConsoleLoggerOptions>>()
//             )
//         )
//     );
// });

builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IAuthUserRepository, AuthUserRepository>();
builder.Services.AddTransient<IUserMapperService, UserMapperService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<ISaltRotationService, SaltRotationService>();

builder.Services.AddTransient<IJwtService, JwtService>();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
//builder.Services.Configure<JwksSettings>(builder.Configuration.GetSection("Jwks"));

builder.Services.AddSingleton<ILoggingClient>(
    new LoggingClient(new LoggerConfig("Dnd.API.Main", null, LogLevel.Information)));

builder.Services.AddHostedService<SaltRotationService>();

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

app.UseCors("AllowLocalhost");

app.Run();