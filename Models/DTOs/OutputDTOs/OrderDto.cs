namespace EndavaProject.Models.DTOs.OutputDTOs
{
    public class OrderDto
    {
        public long OrdersId { get; set; }

        public int? NumberOfTickets { get; set; }

        public DateTime? OrderedAt { get; set; }

        public double? TotalPrice { get; set; }

        public long? CustomersId { get; set; }

        public long? TicketCategoryId { get; set; }

        public CustomerDto? Customers { get; set; }

        public TicketCategoryDto? TicketCategory { get; set; }
    }
}