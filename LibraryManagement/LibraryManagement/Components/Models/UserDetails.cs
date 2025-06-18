using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Components.Models
{
    public enum Gender{Female,Male,Others}
    public class UserDetails
    {
        //         a.	UserID(Auto Increment – SF3000)
        // b.	UserName
        // c.	Gender
        // d.	Department 
        // e.	MobileNumber
        // f.	MailID
        // g.	WalletBalance

        public string UserName { get; set; }
        public Gender Gender { get; set; }
        public string Department { get; set; }
        public string MobileNumber { get; set; }
        public string MailID { get; set; }
        public string Password { get; set; }
        public int WalletBalance { get; set; }
        public int UserID { get; set; }
        public string Role{ get; set; }









    }
}