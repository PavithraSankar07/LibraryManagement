using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Components.Models;

namespace LibraryManagement.Components.Service
{
    public class UserService
    {
        // Get all userdetails
        public List<UserDetails> GetAllUser()
        {
            return ApplicationDBContext.users;
        }
        // get mailid
        public UserDetails GetMailID(string mailid)
        {
            var mail = ApplicationDBContext.users.Find(u => u.Email == mailid);
            return mail;
        }
        // get userid
        public UserDetails GetUserID(int userID)
        {
            var user = ApplicationDBContext.users.Find(u => u.UserID == userID);
            return user;
        }
        // add user
        public void AddUser(UserDetails userDetails)
        {
            Console.WriteLine("call adduser method");
            int count = ApplicationDBContext.users.Count;
            if (count != 0)
            {
                userDetails.UserID = ApplicationDBContext.users[ApplicationDBContext.users.Count - 1].UserID + 1;
                Console.WriteLine(userDetails.UserID);
            }
            else
            {
                userDetails.UserID = 1;
            }
            userDetails.Role = "User";
            ApplicationDBContext.users.Add(userDetails);
            Console.WriteLine("SF");
        }
        // wallet recharge
        public bool WalletRecharge(int amount, int userid)
        {
            var user = GetUserID(userid);
            if (user == null)
            {
                return false;
            }
            else
            {
                if (amount > 0)
                {
                    user.WalletBalance += amount;
                    return true;
                }
                return false;
            }
        }
        // wallet deduct
        public bool AmountDeduct(int amount, int userid)
        {
            var user = GetUserID(userid);
            if (user == null)
            {
                return false;
            }
            if (amount <= user.WalletBalance)
            {
                user.WalletBalance -= amount;
                return true;
            }
            return false;
        }

    }
}