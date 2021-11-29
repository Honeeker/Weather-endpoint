using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModularEndpoint.Modules.Weather.Core.Entities;

namespace ModularEndpoint.Modules.Weather.Core.DAL.Configurations
{
    public class StationConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
             builder
                .ToTable("stations")
                .HasKey(p => new {p.Id, p.Key});
            builder
                .Property(p => p.Id)
                .HasColumnName("id");
            builder
                .Property(p => p.Name)
                .HasColumnName("name");
            builder
                .Property(p => p.Key)
                .HasColumnName("key");
        }
    }
}