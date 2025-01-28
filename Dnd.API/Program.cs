using Dnd.API.Extensions;
using Dnd.API.Infrastructure;
using Dnd.API.Models.Characters.Implementations;
using Dnd.API.Models.Rolls;
using Dnd.API.Models.Rolls.Implementations;
using Dnd.API.Models.Rolls.Interfaces;
using Dnd.API.Repositories;
using Dnd.API.Services;
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

builder.Services.AddTransient<ICharacterRepository, CharacterRepository<Character>>();
builder.Services.AddTransient<ICharacterService, CharacterService>(); //<>()
builder.Services.AddTransient<IRollRepository, RollRepository<DiceRollBase>>();
builder.Services.AddTransient<IRollMapperService, RollMapperService>();
builder.Services.AddTransient<IRollService, RollService>();
builder.Services.AddTransient<IClassMapperService, ClassMapperService>();
builder.Services.AddTransient<IDiceSimulationFactory, DiceSimulationFactory>();

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