using System.Collections.Immutable;
using Dnd.Roll.API.Models.Characters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dnd.Roll.API.Infrastructure.EntityConfigurations;

public class ClassEntityConfiguration : IEntityTypeConfiguration<Class>
{
    public void Configure(EntityTypeBuilder<Class> builder)
    {
        builder.ToTable("Classes");
        builder.HasKey(x => x.Id);
    }
}
