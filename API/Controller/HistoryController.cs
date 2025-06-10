using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{[ApiController]
    [Route("api/history")]
    public class HistoryController : ControllerBase
    {
        // Get book
        [HttpGet("{userid}")]
        public IActionResult GetUserBorrowHistory(string userid)
        {
            var userHistory = ApplicationDBContext.borrowList
                               .Where(b => b.UserID == userid)
                               .ToList();

            return Ok(userHistory);
        }
[HttpPost("return/{borrowId}")]
public IActionResult ReturnBook(string borrowId)
{
    var borrow = ApplicationDBContext.borrowList.FirstOrDefault(b => b.BorrowID == borrowId);
    if (borrow == null)
        return NotFound("Borrow record not found.");

    borrow.BookingStatus = BookingStatus.Returned;
    borrow.PaidFineAmount = 0;

    return Ok(new { message = "Book returned successfully." });
}


// [HttpPost("return/{borrowId}")]
// public IActionResult ReturnBook(string borrowId, [FromBody] JsonElement body)
// {
//     var borrow = ApplicationDBContext.borrowList.FirstOrDefault(b => b.BorrowID == borrowId);
//     if (borrow == null)
//         return NotFound("Borrow record not found.");

//     var user = ApplicationDBContext.Users.FirstOrDefault(u => u.UserID == borrow.UserID);
//     if (user == null)
//         return NotFound("User not found.");

//     // Get isDamaged from JSON manually (no extra class used)
//     bool isDamaged = false;
//     if (body.TryGetProperty("isDamaged", out JsonElement damagedProp))
//     {
//         isDamaged = damagedProp.GetBoolean();
//     }

//     int daysBorrowed = (DateTime.Now - borrow.BorrowedDate).Days;
//     int overdueDays = daysBorrowed > 15 ? daysBorrowed - 15 : 0;

//     int fine = overdueDays;
//     if (isDamaged)
//     {
//         fine += 30; // damage fine is 30
//     }

//     // Only check wallet balance if fine > 0
//     if (fine > 0 && user.WalletBalance < fine)
//     {
//         return BadRequest("Insufficient wallet balance to return the book.");
//     }

//     // Deduct fine if any
//     if (fine > 0)
//     {
//         user.WalletBalance -= fine;
//     }

//     // Update borrow record
//     borrow.BookingStatus = BookingStatus.Returned;
//     borrow.PaidFineAmount = fine;

//     return Ok(new
//     {
//         message = "Book returned successfully.",
//         fineCharged = fine,
//         walletBalance = user.WalletBalance
//     });
// }



    }
}