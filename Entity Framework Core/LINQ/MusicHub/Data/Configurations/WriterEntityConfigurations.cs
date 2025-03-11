using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;
using static MusicHub.Data.Models.EntityValidationConstants.WriterConstants;

namespace MusicHub.Data.Configurations
{
    public class WriterEntityConfigurations : IEntityTypeConfiguration<Writer>
    {
        public void Configure(EntityTypeBuilder<Writer> entity)
        {
            entity
                .HasKey(w => w.Id);

            entity
                .Property(w => w.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(WriterNameMaxLength);

            entity
                .Property(w => w.Pseudonym)
                .IsRequired(false);
        }
    }
}
