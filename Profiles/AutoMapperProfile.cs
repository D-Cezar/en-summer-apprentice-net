using AutoMapper;
using EndavaProject.Models;
using EndavaProject.Models.DTOs;

namespace EndavaProject.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<TicketCategory, TicketCategoryDto>().ReverseMap();
        }
    }
}