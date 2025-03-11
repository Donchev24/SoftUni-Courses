using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;
using static MusicHub.Data.Models.EntityValidationConstants.ProducerConstants;

namespace MusicHub.Data.Configurations
{
    public class ProducerEntityConfigurations : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> entity)
        {
            entity
                .HasKey(p => p.Id);

            entity
                .Property(p => p.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(ProducerNameMaxLength);

            entity
                .Property(p => p.Pseudonym)
                .IsRequired(false);

            entity
                .Property(p => p.PhoneNumber)
                .IsRequired(false);

        }
    }
}
