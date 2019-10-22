using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TemplateConfiguration : IEntityTypeConfiguration<TemplateEntity>
    {
        public void Configure(EntityTypeBuilder<TemplateEntity> builder)
        {
            // ENTITY CONFIGURATIONS

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasMaxLength(60);
        }
    }
}
