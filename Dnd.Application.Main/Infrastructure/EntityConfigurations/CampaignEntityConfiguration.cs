using Dnd.Application.Main.Models.Campaigns;
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
            .WithOne(ucc => (Campaign)ucc._Campaign)
            .HasForeignKey(ucc => ucc.CampaignId);
    }
}