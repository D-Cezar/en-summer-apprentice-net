namespace EndavaProject.Models.DTOs.OutputDTOs
{
    public class EventDto
    {
        public string? Description { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Name { get; set; }

        public DateTime? StartDate { get; set; }

        public long? EventTypeId { get; set; }

        public VenueDto Venue { get; set; }

        public ICollection<TicketCategoryDto> ticketCategory { get; set; }
    }
}