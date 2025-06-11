using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{ [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        // GET: api/books
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(ApplicationDBContext.books);
        }

        // POST: api/books
        [HttpPost]
        public IActionResult AddBook([FromBody] BookDetails newBook)
        {
            if (newBook == null)
            {
                Console.WriteLine("Received null book");
                return BadRequest("Invalid book data");
            }

            Console.WriteLine($"Received book: {newBook.BookName}, {newBook.AuthorName}, {newBook.Availability}");

            int maxId = ApplicationDBContext.books.Select(b => int.Parse(b.BookID.Replace("BID", ""))).DefaultIfEmpty(1000).Max();
            newBook.BookID = "BID" + (maxId + 1);
            newBook.SerialNumber++;
            ApplicationDBContext.books.Add(newBook);
            return Ok(newBook);
        }
        // PUT: api/books/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateBook(string id, [FromBody] BookDetails updatedBook)
        {
            var book = ApplicationDBContext.books.FirstOrDefault(b => b.BookID == id);
            if (book == null)
                return NotFound();

            book.BookName = updatedBook.BookName;
            book.AuthorName = updatedBook.AuthorName;
            book.Availability = updatedBook.Availability;

            return Ok(book);
        }

        // DELETE: api/books/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(string id)
        {
            var book = ApplicationDBContext.books.FirstOrDefault(b => b.BookID == id);
            if (book == null)
                return NotFound();

            ApplicationDBContext.books.Remove(book);
            return Ok();
        }
        



        
    }
}