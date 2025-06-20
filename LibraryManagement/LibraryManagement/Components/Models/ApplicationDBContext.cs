using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Components.Models
{
    public class ApplicationDBContext
    {
        public static List<UserDetails> users = new()
        { new UserDetails
        {
            UserName = "Pavi",
            Gender = "Female",
            Department = "Maths",
            MobileNumber = "1234567890",
            Email = "pavi@gmail.com",
            WalletBalance = 1000,
            Password="123",
            UserID = 1,
            Role="Admin"
        }

        };

          public static List<BookDetails> books = new()
        {
            new BookDetails(){BookID = 1, BookName = "HTML", AuthorName = "Web", Availability = "Available"},
            new BookDetails(){BookID = 2, BookName = "CSS", AuthorName = "Web", Availability = "Damaged"},
            new BookDetails(){BookID = 3, BookName = "JS", AuthorName = "Web", Availability = "Issued"},
            new BookDetails(){BookID = 4, BookName = "TS", AuthorName = "Web", Availability = "Issued"},
            new BookDetails(){BookID = 5, BookName = "HTML1", AuthorName = "Web", Availability = "Available"},
            new BookDetails(){BookID = 6, BookName = "HTML2", AuthorName = "Web", Availability = "Available"},
            new BookDetails(){BookID = 7, BookName = "HTML3", AuthorName = "Web", Availability = "Available"},
            new BookDetails(){BookID = 8, BookName = "HTML4", AuthorName = "Web", Availability = "Damaged"}
        };


        public static List<BorrowDetails> borrows = new()
        {
            new BorrowDetails
            {
               BorrowID=1,
               BookID=1,
               UserID=1,
               BorrowedDate=DateTime.Today,
               BookingStatus=BookingStatus.Borrowed,
               PaidFineAmount=300
            },
              new BorrowDetails
            {
               BorrowID=2,
               BookID=3,
               UserID=1,
               BorrowedDate=DateTime.Today,
               BookingStatus=BookingStatus.Returned,
               PaidFineAmount=0
            },
            new BorrowDetails
            {
                BorrowID=3,
                BookID=4,
                UserID=2,
                BorrowedDate=DateTime.Today,
                BookingStatus=BookingStatus.Borrowed,
                
            }
        };
    }
}