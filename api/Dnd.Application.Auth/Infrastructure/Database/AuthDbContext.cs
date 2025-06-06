﻿using Dnd.Application.Auth.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dnd.Application.Auth.Infrastructure.Database;

public class AuthDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    private static readonly string Salt = "xAgPEpjAIRRqkGLmYnibFQ==";
    private static readonly string HashedPassword = "ubRuRiajwISrw7X1+YOlqCMlX1Z3UlC40uiX7oTIrGM=";

    public AuthDbContext(DbContextOptions<AuthDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<AuthUser> AuthUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<AuthUser>().HasData(
            new AuthUser(
                id: 1,
                username: "admin",
                salt: Salt,
                hashedPassword: HashedPassword,
                email: "test@localhost",
                role: "Admin"
            )
        );
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseNpgsql(new NpgsqlConnection(_configuration.GetConnectionString("Postgres")));
    // }
}