using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PersonalController : ControllerBase
    {
        // private static List<UserDetails> users = ApplicationDBContext.GetDefaultUsers();

        // signup
        [HttpPost("signup")]
        public IActionResult SignUp([FromBody] UserDetails newUser)
        {
            if (ApplicationDBContext.Users.Any(u => u.MailID.Equals(newUser.MailID, StringComparison.OrdinalIgnoreCase)))
            {
                return BadRequest("User already exists");
            }

            // Extract numeric part from UserID (like "SF0001" -> 1)
            int maxId = ApplicationDBContext.Users
                .Select(u => int.TryParse(u.UserID.Replace("SF", ""), out int n) ? n : 0)
                .DefaultIfEmpty(0)
                .Max();

            newUser.UserID = $"SF{(maxId + 1):D4}";  // e.g. SF0005

            ApplicationDBContext.Users.Add(newUser);
            return Ok(newUser);
        }

        // login
        [HttpGet("signin/{mailid}/{password}")]
public IActionResult SignIn(string mailid, string password)
{
    var user = ApplicationDBContext.Users.FirstOrDefault(u =>
        u.MailID.Equals(mailid, StringComparison.OrdinalIgnoreCase) &&
        u.Password == password);

    if (user == null)
    {
        return NotFound("Invalid email or password.");
    }

    return Ok(user);
}


        // [HttpGet("signin{mailid}/{password}")]
        // public IActionResult SignIn(string mailid, string password)
        // {
        //     var user = ApplicationDBContext.Users.Find(user => user.MailID.Equals(mailid.ToLower()) && user.Password.Equals(password));
        //     if (user.Equals(null))
        //     {
        //         return NotFound();
        //     }
        //     return Ok(user);
        // }
        // [HttpPost("signin")]
        // public IActionResult SignIn([FromBody] UserDetails login)
        // {
        //     if (login == null || string.IsNullOrEmpty(login.MailID) || string.IsNullOrEmpty(login.Password))
        //         return BadRequest("Invalid login data.");

        //     var user = ApplicationDBContext.Users.FirstOrDefault(u => u.MailID == login.MailID.Trim() && u.Password == login.Password.Trim());

        //     if (user == null)
        //     {
        //         return Unauthorized("Invalid email or password.");
        //     }

        //     Console.WriteLine(login.MailID);
        //     return Ok(user);
        // }

        //    Walletrecharge  
        [HttpPost("recharge/{userID}/{amount}")]
        public IActionResult WalletRecharge(string userID, int amount)
        {
            var user = ApplicationDBContext.Users.Find(user => user.UserID.Equals(userID));
            if (user == null)
            {
                return NotFound();
            }
            user.WalletBalance += amount;
            return Ok();
        }


    }
}