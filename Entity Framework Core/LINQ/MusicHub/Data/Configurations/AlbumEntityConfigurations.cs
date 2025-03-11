using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;
using static MusicHub.Data.Models.EntityValidationConstants.AlbumConstants;

namespace MusicHub.Data.Configurations
{
    public class AlbumEntityConfigurations : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> entity)
        {
            entity
                .HasKey(a => a.Id);

            entity
                .Property(a => a.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(AlbumNameMaxLength);

            entity
                .Property(a => a.ReleaseDate)
                .IsRequired();

            entity
                .Property(a => a.ProducerId)
                .IsRequired(false);


            // Relations

            entity
                .HasOne(a => a.Producer)
                .WithMany(p => p.Albums)
                .HasForeignKey(a => a.ProducerId);

        }
    }
}
