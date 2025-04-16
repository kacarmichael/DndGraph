using Dnd.Application.Main.Models.Characters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dnd.Application.Main.Infrastructure.EntityConfigurations;

public class CharacterStatsEntityConfiguration : IEntityTypeConfiguration<CharacterStats>
{
    public void Configure(EntityTypeBuilder<CharacterStats> builder)
    {
        builder.ToTable("CharacterStats");

        builder.HasKey(cs => cs.Id);

        builder.HasOne(cs => (Character)cs.Character)
            .WithOne(c => (CharacterStats)c.Stats)
            .HasForeignKey<Character>(cs => cs.Id);
    }
}