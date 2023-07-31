using EndavaProject.Models.DTOs.OutputDTOs;

namespace EndavaProject.Models.DTOs.InputDTOs
{
    public class OrderInDto
    {
        public int? NumberOfTickets { get; set; }

        public long? CustomersId { get; set; }

        public long? TicketCategoryId { get; set; }
    }
}