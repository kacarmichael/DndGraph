// using Dnd.Roll.API.Models.Rolls;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace Dnd.Roll.API.Infrastructure.EntityConfigurations;
//
// public class AbilityCheckRollEntityConfiguration : IEntityTypeConfiguration<AbilityCheckRoll>
// {
//     public void Configure(EntityTypeBuilder<AbilityCheckRoll> builder)
//     {
//         builder.ToTable("Rolls");
//         builder.HasKey(x => x.Id);
//         builder.Property(ab => ab.Ability).HasMaxLength(50);
//         builder.HasOne(ab => ab.Roller).WithMany().HasForeignKey(ab => ab.Roller.Id);
//     }
// }