using Dnd.Application.Main.Models.Characters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dnd.Application.Main.Infrastructure.EntityConfigurations;

public class CharacterEntityConfiguration : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.ToTable("Rolls");

        builder.HasKey(x => x.Id);

        builder.Property(c => c.Name)
            .HasMaxLength(50);

        //builder.Property(c => c.Class).HasMaxLength(50);

        builder.Property(c => c.AC)
            .HasColumnType("int");

        //builder.HasMany(c => c.Classes).WithMany(c => c.Characters);

        builder.Property(c => c.Stats)
            .HasColumnType("jsonb");

        builder.Property(c => c.Classes)
            .HasColumnType("jsonb");
    }
}