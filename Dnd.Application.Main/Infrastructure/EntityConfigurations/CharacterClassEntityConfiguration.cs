using Dnd.Application.Main.Models.Intermediate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dnd.Application.Main.Infrastructure.EntityConfigurations;

public class CharacterClassEntityConfiguration : IEntityTypeConfiguration<CharacterClass>
{
    public void Configure(EntityTypeBuilder<CharacterClass> builder)
    {
        builder.ToTable("CharacterClasses");
        builder.HasKey(cc => new { cc.CharacterId, cc.ClassId });
        // builder.HasOne(cc => (Character)cc._character)
        //     .WithMany(c => c.Classes)
        //     .HasForeignKey(c => c.CharacterId);
    }
}