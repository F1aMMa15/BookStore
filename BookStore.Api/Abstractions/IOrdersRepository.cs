using BookStore.Api.Entities;
using System.Linq.Expressions;

namespace BookStore.Api.Abstractions
{
    public interface IOrdersRepository
    {
        Task<List<Order>> GetAllOrdersAsync<TKey>(Expression<Func<Order, TKey>> filter);
        Task<Order?> GetOrderByIdAsync(int id);
        Task<Order> CreateOrderAsync(int[] books);
    }
}
