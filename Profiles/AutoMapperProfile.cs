using AutoMapper;
using EndavaProject.Models;
using EndavaProject.Models.DTOs.InputDTOs;
using EndavaProject.Models.DTOs.OutputDTOs;

namespace EndavaProject.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<TicketCategory, TicketCategoryDto>().ReverseMap();
            CreateMap<Event, EventDto>().ForMember(e => e.ticketCategory, tg => tg.MapFrom(src => src.TicketCategories)).ReverseMap();
            CreateMap<Venue, VenueDto>().ReverseMap();
            CreateMap<OrderInDto, Order>().ForMember(x => x.OrderedAt, y => y.MapFrom(_ => DateTime.Now));
        }
    }
}