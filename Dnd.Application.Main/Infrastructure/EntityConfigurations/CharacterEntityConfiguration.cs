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
        builder.ToTable("Characters");

        builder.HasKey(c => c.Id);

        // builder.HasOne(c => (CharacterStats)c.Stats)
        //     .WithOne(cs => (Character)cs.Character)
        //     .HasForeignKey<CharacterStats>(cs => cs.CharacterId);

        builder.HasMany(c => c.Classes)
            .WithOne(cc => (Character)cc._character)
            .HasForeignKey(cc => cc.CharacterId);

        builder.HasMany(c => c.Campaigns)
            .WithOne(ucc => (Character)ucc._Character)
            .HasForeignKey(ucc => ucc.CharacterId);
    }
}