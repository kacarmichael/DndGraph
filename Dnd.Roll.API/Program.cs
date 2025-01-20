using Dnd.Roll.API.Extensions;
using Dnd.Roll.API.Infrastructure;
using Dnd.Roll.API.Repositories;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddTransient<ICharacterRepository, CharacterRepository>();
builder.Services.AddTransient<IRollRepository, RollRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

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

app.Run();