using EventTicketingSystem.Domain.Enums;

namespace EventTicketingSystem.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; } = null!;

        public int EventSeatId { get; set; }

        public EventSeat EventSeat { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiresAt { get; set; }

        public ReservationStatus Status { get; set; }

        public Booking? Booking { get; set; }
    }
}