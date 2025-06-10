using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{ public enum Gender { Male, Female, Others }
    public class UserDetails
    {
        

        public string UserID { get; set; }
        public string UserName { get; set; }
        public long PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public string Department { get; set; }
        public string MailID { get; set; }
        public string Password { get; set; }
        public double WalletBalance { get; set; }
     
    
    }
}