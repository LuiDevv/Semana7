using Microsoft.AspNetCore.Mvc;
using BookManagementAPI.Models;

namespace BookManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> Books = new List<Book>
        {
            new Book { Id = 1, Title = "The Hobbit", Author = "J.R.R. Tolkien", Genre = "Fantasy", PublishedYear = 1937 },
            new Book { Id = 2, Title = "1984", Author = "George Orwell", Genre = "Dystopian", PublishedYear = 1949 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            return Ok(Books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound(new { Message = "Book not found." });
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> CreateBook([FromBody] Book newBook)
        {
            if (!newBook.IsValid())
                return BadRequest(new { Message = "Invalid book data." });

            newBook.Id = Books.Count > 0 ? Books.Max(b => b.Id) + 1 : 1;
            Books.Add(newBook);
            return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var existingBook = Books.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
                return NotFound(new { Message = "Book not found." });

            if (!updatedBook.IsValid())
                return BadRequest(new { Message = "Invalid book data." });

            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.Genre = updatedBook.Genre;
            existingBook.PublishedYear = updatedBook.PublishedYear;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound(new { Message = "Book not found." });

            Books.Remove(book);
            return NoContent();
        }
    }
}
