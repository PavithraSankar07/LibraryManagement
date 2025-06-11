using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public enum BookingStatus{Default, Borrowed, Returned}
    public class BorrowDetails
    {
        //         •	BorrowID (Auto Increment – LB2000)
        // •	BookID 
        // •	UserID
        // •	BorrowedDate – (Current Date)
        // •	BookingStatus – (Enum - Default, Borrowed, Returned)
        // •	PaidFineAmount
          public int SerialNumber { get; set; }
        public string? BorrowID { get; set; }
        public string BookID { get; set; }
        public string UserID { get; set; }
        public DateTime BorrowedDate { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public int PaidFineAmount{ get; set; }


    }
}