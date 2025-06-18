using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Components.Models;
using LibraryManagement.Components.Service;
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
        public IActionResult GetUser()
        {
            return Ok(_userService.GetAllUser());
        }
        // getby mailid
        [HttpGet("getmailid")]
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
        [HttpPost("adduser")]
        public IActionResult AddUser([FromBody] UserDetails userDetails)
        {
            var existinguser = _userService.GetMailID(userDetails.MailID);
            if (existinguser == null)
            {
                return Conflict("Exist");
            }
            _userService.AddUser(userDetails);
            return Ok();
        }
        // wallet
    }
}