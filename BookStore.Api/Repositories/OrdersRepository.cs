using BookStore.Api.Abstractions;
using BookStore.Api.Data;
using BookStore.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookStore.Api.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IBooksRepository _booksRepository;

        public OrdersRepository(AppDbContext dbContext, IBooksRepository booksRepository)
        {
            _dbContext = dbContext;
            _booksRepository = booksRepository;
        }

        public async Task<Order> CreateOrderAsync(int[] booksIds)
        {
            var books = await _booksRepository.GetBooksByIdAsync(booksIds);

            var order = new Order { Books = books };

            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<List<Order>> GetAllOrdersAsync<TKey>(Expression<Func<Order, TKey>> filter)
        {
            return await _dbContext.Orders
                .Include(o => o.Books)
                .OrderBy(filter)
                .ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _dbContext.Orders
                .Where(b => b.Id == id)
                .Include(o => o.Books)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
