using Dnd.Auth.Infrastructure;
using Dnd.Auth.Models.Implementations;
using Dnd.Auth.Services.Implementations;
using Dnd.Auth.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseInMemoryDatabase("Identity"));

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowLocalhost",
            builder =>
            {
                builder.WithOrigins("http://localhost:3004", "https://localhost:3004").AllowAnyHeader()
                    .AllowAnyMethod();
            });
    }
);

builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.AddDebug();
});

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddTransient<IJwtService, JwtService>();

// Console.WriteLine("Starting IJwtService Creation");
// builder.Services.AddTransient<IJwtService>(provider =>
// {
//     Console.WriteLine("Inside AddTransient");
//     var config = provider.GetService<IConfiguration>();
//     if (config == null)
//     {
//         throw new InvalidOperationException("IConfiguration is null");
//     }
//     Console.WriteLine("Made it here");
//     return new JwtService(config["Jwt:Secret"], config["Jwt:Issuer"], config["Jwt:Audience"]);
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowLocalhost");

app.Run();