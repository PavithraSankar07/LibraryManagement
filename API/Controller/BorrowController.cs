using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BorrowController : ControllerBase
    {
        [HttpPost("borrow")]
        public IActionResult BorrowBook([FromBody] BorrowDetails request)
        {
            var book = ApplicationDBContext.books.FirstOrDefault(b => b.BookID == request.BookID);
            if (book == null)
                return NotFound("Book not found.");

            if (book.Availability != Availability.Available)
            {
                if (book.Availability == Availability.Issued)
                {
                    var borrowRecord = ApplicationDBContext.borrowList
                        .Where(b => b.BookID == book.BookID && b.BookingStatus == BookingStatus.Borrowed)
                        .OrderByDescending(b => b.BorrowedDate)
                        .FirstOrDefault();

                    if (borrowRecord != null)
                    {
                        var nextAvailableDate = borrowRecord.BorrowedDate.AddDays(15);
                        return BadRequest($"The book will be available on {nextAvailableDate:dd-MM-yyyy}.");
                    }
                }
                return BadRequest($"Book is {book.Availability}.");
            }
            var userBorrows = ApplicationDBContext.borrowList
                .Where(b => b.UserID == request.UserID && b.BookingStatus == BookingStatus.Borrowed)
                .Count();
            if (userBorrows >= 3)
                return BadRequest("You have borrowed 3 books already.");

            var borrowID = $"LB{ApplicationDBContext.borrowList.Count + 2000}";

            var newBorrow = new BorrowDetails
            {
                BorrowID = borrowID,
                BookID = request.BookID,
                UserID = request.UserID,
                BorrowedDate = DateTime.Today,
                BookingStatus = BookingStatus.Borrowed,
                PaidFineAmount = 0
            };

            ApplicationDBContext.borrowList.Add(newBorrow);
            Console.WriteLine(newBorrow.UserID);
            foreach (var k in ApplicationDBContext.borrowList)
            {
                Console.WriteLine(k.BookID);
            }
            book.Availability = Availability.Issued;

            return Ok(new { Message = $"Book Borrowed successfully. Borrow ID: {borrowID}" });
        }


    }
}
