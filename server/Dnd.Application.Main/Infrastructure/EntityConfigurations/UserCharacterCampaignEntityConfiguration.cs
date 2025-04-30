using Dnd.Application.Main.Models.Intermediate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dnd.Application.Main.Infrastructure.EntityConfigurations;

public class UserCharacterCampaignEntityConfiguration : IEntityTypeConfiguration<UserCharacterCampaign>
{
    public void Configure(EntityTypeBuilder<UserCharacterCampaign> builder)
    {
        builder.ToTable("UserCharacterCampaigns");
        builder.HasKey(ucc => new { ucc.UserId, ucc.CharacterId, ucc.CampaignId });
    }
}