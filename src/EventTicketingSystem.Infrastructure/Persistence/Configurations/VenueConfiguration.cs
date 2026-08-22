using EventTicketingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventTicketingSystem.Infrastructure.Persistence.Configurations
{
    public class VenueConfiguration : IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Address).IsRequired().HasMaxLength(100);

            builder.HasMany(e => e.Seats)
                   .WithOne(s => s.Venue)
                   .HasForeignKey(s => s.VenueId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Events)
           .WithOne(e => e.Venue)
           .HasForeignKey(s => s.VenueId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
