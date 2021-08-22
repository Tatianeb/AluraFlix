using AluraFlix.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluraFlix.Data.Mappings
{
    public class VideoMapping:IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Titulo)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Url)
                .IsRequired()
                .HasColumnType("varchar(100)");
        }
    }
}