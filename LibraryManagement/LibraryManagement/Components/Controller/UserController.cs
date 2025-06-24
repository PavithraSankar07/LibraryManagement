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
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        // get the user
        [HttpGet("getuser")]
        [Authorize(Roles ="Admin,User")]
        public IActionResult GetUser()
        {
            return Ok(_userService.GetAllUser());
        }
        // getby mailid
        [HttpGet("getmailid")]
        [Authorize(Roles ="Admin,User")]
        public IActionResult GetEmail(string mailid)
        {
            var user = _userService.GetMailID(mailid);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }
        // add 

        [HttpPost("newuser")]
        [Authorize(Roles ="Admin")]
        public IActionResult AddUser([FromBody] UserDetails userDetails)
        {
            Console.WriteLine("Method calling");
            var existinguser = _userService.GetMailID(userDetails.Email);
            if (existinguser != null)
            {
                Console.WriteLine("F");
                return Conflict("Exist");
            }
            Console.WriteLine("Su");
            _userService.AddUser(userDetails);
            return Ok();
        }
        // wallet
           [HttpPut("deposit/{mailID}/{amount}")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult RechargeWalletBalance(string mailID, int amount)
        {
            var user = _userService.GetMailID(mailID);
            if (user != null)
            {
                user.WalletBalance += amount;
                return Ok();
            }
            Console.WriteLine(user.WalletBalance);
            return NotFound();
        }
    }
}