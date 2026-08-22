using EventTicketingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventTicketingSystem.Infrastructure.Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .HasMaxLength(500);

            builder.Property(e => e.StartDate)
                .IsRequired();

            builder.Property(e => e.EndDate)
                .IsRequired();

            builder.Property(e => e.Status)
                .IsRequired();

            builder.HasMany(e => e.EventSeats)
                .WithOne(es => es.Event)
                .HasForeignKey(es => es.EventId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
