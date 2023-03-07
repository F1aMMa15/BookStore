using AutoMapper;
using BookStore.Api.Entities;
using BookStore.Api.Models;

namespace BookStore.Api.MappingProfiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, GetBook>();
        }
    }
}
