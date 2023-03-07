using BookStore.Api.Abstractions;
using BookStore.Api.Data;
using BookStore.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookStore.Api.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly AppDbContext _dbContext;

        public BooksRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Book>> GetAllBooksAsync<TKey>(Expression<Func<Book, TKey>> filter)
        {
            return await _dbContext.Books.OrderBy(filter).ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<Book>> GetBooksByIdAsync(int[] ids)
        {
            return await _dbContext.Books.Where(b => ids.Contains(b.Id)).ToListAsync();
        }
    }
}
