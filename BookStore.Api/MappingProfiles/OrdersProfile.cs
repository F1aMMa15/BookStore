using AutoMapper;
using BookStore.Api.Entities;
using BookStore.Api.Models;

namespace BookStore.Api.MappingProfiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Order, GetOrder>();
        }
    }
}
