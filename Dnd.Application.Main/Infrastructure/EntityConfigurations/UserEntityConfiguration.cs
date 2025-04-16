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

        builder.HasMany(u => u.Characters)
            .WithOne(c => (DomainUser)c.User)
            .HasForeignKey(c => c.UserId);

        builder.HasMany(u => u.CampaignsPlayed)
            .WithOne(ucc => (DomainUser)ucc._User)
            .HasForeignKey(ucc => ucc.UserId);

        builder.HasMany(u => u.CampaignsOwned)
            .WithOne(co => (DomainUser)co.Owner)
            .HasForeignKey(co => co.Id);

        builder.HasMany(u => u.CampaignsDmed)
            .WithOne(cdm => (DomainUser)cdm.DungeonMaster)
            .HasForeignKey(cdm => cdm.Id);
    }
}