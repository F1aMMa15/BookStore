using BookStore.Api.Entities;
using System.Linq.Expressions;

namespace BookStore.Api.Abstractions
{
    public interface IBooksRepository
    {
        Task<List<Book>> GetAllBooksAsync<TKey>(Expression<Func<Book, TKey>> filter);
        Task<Book?> GetBookByIdAsync(int id);
        Task<List<Book>> GetBooksByIdAsync(int[] ids);

    }
}
