using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;
using static MusicHub.Data.Models.EntityValidationConstants.PerformerConstants;

namespace MusicHub.Data.Configurations
{
    public class PerformerEntityConfigurations : IEntityTypeConfiguration<Performer>
    {
        public void Configure(EntityTypeBuilder<Performer> entity)
        {
            entity
                .HasKey(p => p.Id);

            entity
                .Property(p => p.FirstName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(FirstNameMaxLength);

            entity
                .Property(p => p.LastName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(LastNameMaxLength);

            entity
                .Property(p => p.Age)
                .IsRequired();

            entity
               .Property(p => p.NetWorth)
               .IsRequired();
        }
    }
}
