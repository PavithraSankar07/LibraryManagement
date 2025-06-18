using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Components.Models
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
        public int BorrowID { get; set; }
        public int BookID { get; set; }
        public int UserID { get; set; }
        public DateTime BorrowedDate { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public int PaidFineAmount { get; set; }













    }
}