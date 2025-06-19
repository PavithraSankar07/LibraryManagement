using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LibraryManagement.Components.Models;
using LibraryManagement.Components.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Components.Controller
{[ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly UserService _userService;
        public LoginController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] LoginDetails newuser)
        {
            Console.WriteLine("method call api");

            var user = _userService.GetMailID(newuser.Email);
            if (user != null && user.Password == newuser.Password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.Role,user.Role)
                };
                var identity = new ClaimsIdentity(claims, "Cookies");
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("Cookies", principal);
                Console.WriteLine("Login successful");
                return Ok();
            }
            else
            {
                System.Console.WriteLine("fail");
            }
            return Unauthorized();
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            return Redirect("/");
        }
    }
}