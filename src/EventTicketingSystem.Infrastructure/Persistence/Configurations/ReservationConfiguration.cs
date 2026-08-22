using EventTicketingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventTicketingSystem.Infrastructure.Persistence.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.CreatedAt).IsRequired();
            builder.Property(r => r.ExpiresAt).IsRequired();
            builder.Property(r => r.Status).IsRequired();

            builder.HasOne(r => r.User).WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Booking).WithOne(b => b.Reservation).HasForeignKey<Booking>(b => b.ReservationId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.EventSeat).WithMany(e => e.Reservations).HasForeignKey(r => r.EventSeatId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
