using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Components.Models;
using LibraryManagement.Components.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Components.Controller
{
    [Authorize]
    [ApiController]
    [Route("api/book")]
    public class BookDetailsController : ControllerBase
    {
        private readonly BookDetailsService _bookDetailsService;
        public BookDetailsController(BookDetailsService bookDetailsService)
        {
            _bookDetailsService = bookDetailsService;
        }
        // get books
        [HttpGet("getbooks")]
        [Authorize(Roles ="Admin,User")]
        public IActionResult GetBooks()
        {
            return Ok(_bookDetailsService.GetBooks());
        }

        // add book
        [HttpPost("bookadd")]
        [Authorize(Roles ="Admin")]

        public IActionResult AddBook([FromBody] BookDetails newbook)
        {
            var existingbook = _bookDetailsService.GetbookbyID(newbook.BookID);
            if (existingbook == null)
            {
                _bookDetailsService.AddBook(newbook);
                return Ok();
            }
            return NotFound();

        }
        // delete
        [HttpDelete("bookdelete/{bookid}")]
        [Authorize(Roles ="Admin")]
        public IActionResult DeleteBook(int bookid)
        {
            if (_bookDetailsService.Delete(bookid))
            {
                return Ok();
            }
            return NotFound();
        }
        // edit
        [HttpPut("editbook")]
          [Authorize(Roles ="Admin")]
        public IActionResult EditMedicine([FromBody] BookDetails book)
        {
            if (_bookDetailsService.EditBook(book))
            {
                return Ok();
            }
            return NotFound();
        }
       
    }
}