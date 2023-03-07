using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Models
{
    public record CreateOrder([Required] int[] BooksIds);
}
