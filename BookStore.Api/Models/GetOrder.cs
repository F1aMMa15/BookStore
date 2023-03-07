using BookStore.Api.Entities;

namespace BookStore.Api.Models
{
    public record GetOrder(int Id, List<GetBook> Books, DateTime CreatedDate);
}
