using Dnd.Application.Main.Models.Campaigns;
using Dnd.Application.Main.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dnd.Application.Main.Infrastructure.EntityConfigurations;

public class CampaignEntityConfiguration : IEntityTypeConfiguration<Campaign>
{
    public void Configure(EntityTypeBuilder<Campaign> builder)
    {
        builder.ToTable("CampaignsPlayed");

        builder.HasKey(c => c.Id);

        builder.HasMany(c => c.UserCharacters)
            .WithOne(ucc => ucc._Campaign)
            .HasForeignKey(ucc => ucc.CampaignId);
        
        builder.HasOne(c => c.Owner)
            .WithMany(u => u.CampaignsOwned)
            .HasForeignKey(c => c.OwnerId);
        
        builder.HasOne(c => c.DungeonMaster)
            .WithMany(u => u.CampaignsDmed)
            .HasForeignKey(c => c.DungeonMasterId);
    }
}