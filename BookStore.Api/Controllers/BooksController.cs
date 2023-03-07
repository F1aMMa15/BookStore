using AutoMapper;
using BookStore.Api.Abstractions;
using BookStore.Api.Entities;
using BookStore.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public BooksController(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks([FromQuery(Name = "filter")] string filter = "title")
        {
            List<Book> books;

            switch (filter)
            {
                case "title": 
                    books = await _booksRepository.GetAllBooksAsync(b => b.Title);
                    break;
                case "date":
                    books = await _booksRepository.GetAllBooksAsync(b => b.PublishDate);
                    break;
                default:
                    ModelState.AddModelError(nameof(filter), "Invalid filter value.");
                    return BadRequest(ModelState);
            }

            var response = _mapper.Map<List<GetBook>>(books);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _booksRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound($"Book with id {id} doesn't exist.");
            }

            var response = _mapper.Map<GetBook>(book);
            return Ok(response);
        }
    }
}
