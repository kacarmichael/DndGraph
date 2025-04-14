using Dnd.Application.Main.Models.Characters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dnd.Application.Main.Infrastructure.EntityConfigurations;

// public class AbilityBlockConverter : ValueConverter<AbilityBlock, (int, int, int, int, int, int)>
// {
//     public AbilityBlockConverter() : base(
//         v => Tuple.Create(
//             v.GetAbility("Strength").Score ?? 0, 
//             v.GetAbility("Dexterity").Score ?? 0, 
//             v.GetAbility("Constitution").Score ?? 0, 
//             v.GetAbility("Intelligence").Score ?? 0, 
//             v.GetAbility("Wisdom").Score ?? 0, 
//             v.GetAbility("Charisma").Score ?? 0
//             ),
//         v => new AbilityBlock(new List<int>() { v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6 })
//     ) { }
// }
public class CharacterEntityConfiguration : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.Ignore(c => c.Stats);
        builder.ToTable("Characters");

        builder.HasKey(x => x.Id);

        builder.Property(c => c.Name)
            .HasMaxLength(50);

        //builder.Property(c => c.Class).HasMaxLength(50);

        builder.Property(c => c.AC)
            .HasColumnType("int");

        //builder.HasMany(c => c.Classes).WithMany(c => c.Characters);

        // builder.Property(c => c.Stats)
        //     .HasConversion(
        //         v => v.ToString(),
        //         v => CharacterStats.FromJson(v)
        //     );

        // builder.Property(c => c.Stats.Abilities.GetAbility("Strength").Score).HasColumnName("StrengthScore");
        // builder.Property(c => c.Stats.Abilities.GetAbility("Dexterity").Score).HasColumnName("DexterityScore");
        // builder.Property(c => c.Stats.Abilities.GetAbility("Constitution").Score).HasColumnName("ConstitutionScore");
        // builder.Property(c => c.Stats.Abilities.GetAbility("Intelligence").Score).HasColumnName("IntelligenceScore");
        // builder.Property(c => c.Stats.Abilities.GetAbility("Wisdom").Score).HasColumnName("WisdomScore");
        // builder.Property(c => c.Stats.Abilities.GetAbility("Charisma").Score).HasColumnName("CharismaScore");
        builder.OwnsOne(c => (CharacterStats)c.Stats, statsBuilder =>
            {
                statsBuilder.Property(s => s.Level).HasColumnName("Level");
                statsBuilder.Property(c => c.StrengthScore).HasColumnName("StrengthScore").HasColumnType("int");
                statsBuilder.Property(c => c.DexterityScore).HasColumnType("int").HasColumnName("DexterityScore");
                statsBuilder.Property(c => c.ConstitutionScore).HasColumnType("int").HasColumnName("ConstitutionScore");
                statsBuilder.Property(c => c.IntelligenceScore).HasColumnType("int").HasColumnName("IntelligenceScore");
                statsBuilder.Property(c => c.WisdomScore).HasColumnType("int").HasColumnName("WisdomScore");
                statsBuilder.Property(c => c.CharismaScore).HasColumnType("int").HasColumnName("CharismaScore");
            }
        );


        //builder.Navigation(c => c.Stats).AutoInclude();

        // builder.Property(c => c.Classes)
        //     .HasColumnType("jsonb");
    }
}