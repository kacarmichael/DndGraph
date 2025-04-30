using Dnd.Application.Main.Models.Characters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dnd.Application.Main.Infrastructure.EntityConfigurations;

public class CharacterStatsEntityConfiguration : IEntityTypeConfiguration<CharacterStats>
{
    public void Configure(EntityTypeBuilder<CharacterStats> builder)
    {
        builder.ToTable("CharacterStats");

        builder.HasKey(cs => cs.StatBlockId);

        builder.HasOne(cs => cs.Character)
            .WithOne(c => c.Stats)
            .HasForeignKey<Character>(cs => cs.Id);
    }
}