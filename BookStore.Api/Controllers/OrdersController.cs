using AutoMapper;
using BookStore.Api.Abstractions;
using BookStore.Api.Entities;
using BookStore.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrdersController(IOrdersRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders([FromQuery(Name = "filter")] string filter = "number")
        {
            List<Order> orders;

            switch (filter)
            {
                case "number":
                    orders = await _orderRepository.GetAllOrdersAsync(o => o.Id);
                    break;
                case "date":
                    orders = await _orderRepository.GetAllOrdersAsync(o => o.CreatedDate);
                    break;
                default:
                    ModelState.AddModelError(nameof(filter), "Invalid filter value.");
                    return BadRequest(ModelState);
            }

            var response = _mapper.Map<List<GetOrder>>(orders);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound($"Order with id {id} doesn't exist.");
            }

            var response = _mapper.Map<GetOrder>(order);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrders(CreateOrder createOrder)
        {
            var order = await _orderRepository.CreateOrderAsync(createOrder.BooksIds);
            var response = _mapper.Map<GetOrder>(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = response.Id}, response);
        }
    }
}
