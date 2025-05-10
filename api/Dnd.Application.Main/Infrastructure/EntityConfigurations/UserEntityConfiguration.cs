using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dnd.Application.Main.Infrastructure.EntityConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<DomainUser>
{
    public void Configure(EntityTypeBuilder<DomainUser> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.HasMany(u => u.Characters as IEnumerable<Character>)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId);

        builder.HasMany(u => u.CampaignsPlayed)
            .WithOne(ucc => ucc._User)
            .HasForeignKey(ucc => ucc.UserId);

        builder.HasMany(u => u.CampaignsOwned)
            .WithOne(co => co.Owner as DomainUser)
            .HasForeignKey(co => co.Id);

        builder.HasMany(u => u.CampaignsDmed)
            .WithOne(cdm => cdm.DungeonMaster)
            .HasForeignKey(cdm => cdm.Id);
    }
}