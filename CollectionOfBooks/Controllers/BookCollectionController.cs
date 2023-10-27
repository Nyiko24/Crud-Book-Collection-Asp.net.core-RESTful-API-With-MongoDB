using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CollectionOfBooks.Models;
using CollectionOfBooks.Services;

namespace CollectionOfBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCollectionController : ControllerBase
    {
        private readonly MongoDBService _mongoDBService;
        public BookCollectionController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookCollection bookCollection)
        {
            await _mongoDBService.CreateAsync(bookCollection);
            return Ok("Created Successfully");
        }

        [HttpGet]
        public async Task<List<BookCollection>> Get()
        {
            return await _mongoDBService.GetAllAsync();
        }

        [HttpGet("byType/{ISBN}")]
        public async Task<IActionResult> GetBooksByType(string ISBN)
        {
            var books = await _mongoDBService.GetBooksByTypeAsync(ISBN);

            if (books == null || books.Count == 0)
            {
                return NotFound();
            }

            return Ok(books);
        }



        [HttpPut("update/{ISBN}")]
        public async Task<IActionResult> UpdateBookByISBN(string ISBN, [FromBody] BookCollection updatedBook)
        {
            var isUpdated = await _mongoDBService.UpdateBookByISBNAsync(ISBN, updatedBook);

            if (!isUpdated)
            {
                return NotFound();
            }

            return Ok("Book updated successfully.");
        }


        [HttpDelete("delete/{ISBN}")]
        public async Task<IActionResult> DeleteBookByISBN(string ISBN)
        {
            var isDeleted = await _mongoDBService.DeleteBookByISBNAsync(ISBN);

            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok("Book deleted successfully.");
        }


    }
}
