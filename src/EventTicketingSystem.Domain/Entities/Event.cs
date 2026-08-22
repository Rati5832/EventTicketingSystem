using EventTicketingSystem.Domain.Enums;

namespace EventTicketingSystem.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
        
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        
        public int VenueId { get; set; }

        public Venue Venue { get; set; } = null!;

        public EventStatus Status { get; set; }

        public ICollection<EventSeat> EventSeats { get; set; } = new List<EventSeat>();
    }
}