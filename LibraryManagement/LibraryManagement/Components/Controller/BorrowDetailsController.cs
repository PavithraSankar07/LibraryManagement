using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Components.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Components.Controller
{

    [ApiController]
    [Route("api/borrow")]
    public class BorrowDetailsController : ControllerBase
    {
        private readonly BorrowDetailsService _borrowDetailService;
        public BorrowDetailsController(BorrowDetailsService borrowDetailService)
        {
            _borrowDetailService = borrowDetailService;
        }
        [HttpPost("borrowed/{bookid}/{mailid}")]
        public IActionResult BorrowBook(int bookid, string mailid)
        {
            Console.WriteLine(bookid);
            Console.WriteLine(mailid);
            var borrow = _borrowDetailService.AddBorrowBook(bookid, mailid);
            Console.WriteLine(mailid);

            return Ok(borrow);
        }
        [HttpPut("cancel/{borrowid}")]
        public IActionResult Cancel(int borrowid)
        {
            int cancelstatus = _borrowDetailService.Cancel(borrowid);
            return Ok(cancelstatus);
        }
       
    }
}