﻿// <auto-generated />
using System;
using Dnd.Application.Auth.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dnd.Application.Auth.Migrations
{
    [DbContext(typeof(AuthDbContext))]
    [Migration("20250312060939_thirdtimecharm")]
    partial class thirdtimecharm
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Dnd.Application.Auth.Models.AuthUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CurrentSalt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FailedLogins")
                        .HasColumnType("integer");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Locked")
                        .HasColumnType("boolean");

                    b.Property<string>("PasswordResetToken")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PreviousSalt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AuthUser", "public");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2000, 1, 1, 6, 0, 0, 0, DateTimeKind.Utc),
                            CurrentSalt = "i69J0wAqt4Nbj6gzsffhsw==",
                            Email = "test@localhost",
                            FailedLogins = 0,
                            HashedPassword = "BjvZ7XTMzY86C7ZVCrbDqDGcj12o4NyjC0kvpcCORiI=",
                            LastLogin = new DateTime(2000, 1, 1, 6, 0, 0, 0, DateTimeKind.Utc),
                            Locked = false,
                            PasswordResetToken = "Not Implemented Yet",
                            PreviousSalt = "",
                            Role = "Admin",
                            Updated = new DateTime(2000, 1, 1, 6, 0, 0, 0, DateTimeKind.Utc),
                            Username = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
