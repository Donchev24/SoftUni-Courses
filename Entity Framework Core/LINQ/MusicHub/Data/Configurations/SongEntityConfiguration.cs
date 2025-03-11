using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;
using static MusicHub.Data.Models.EntityValidationConstants.SongConstants;

namespace MusicHub.Data.Configurations
{
    public class SongEntityConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> entity)
        {
            entity
                .HasKey(s => s.Id);

            entity
                .Property(s => s.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(SongNameMaxLength);

            entity
                .Property(s => s.Duration)
                .IsRequired();

            entity
                .Property(s => s.CreatedOn)
                .IsRequired();

            entity
                .Property(s => s.Genre)
                .IsRequired();

            entity
                .Property(s => s.AlbumId)
                .IsRequired(false);

            entity
                .Property(s => s.WriterId)
                .IsRequired();

            entity
                .Property(s => s.Price)
                .IsRequired();

            //relations

            entity
                .HasOne(s => s.Writer)
                .WithMany(w => w.Songs)
                .HasForeignKey(s => s.WriterId);

            entity
                .HasOne(s => s.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.AlbumId);
        }
    }
}
