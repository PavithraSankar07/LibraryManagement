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
            Gender = Gender.Female,
            Department = "Maths",
            MobileNumber = "1234567890",
            MailID = "pavi@gmail.com",
            WalletBalance = 1000,
            UserID = 1,
            Role="Admin"
        }

        };

        public static List<BookDetails> books = new()
        {
            new BookDetails
            {
                BookID=1,
                BookName="C#",
                AuthorName="Pavi",
                Availability=Availability.Available
            },
            new BookDetails
        {
            BookID=2,
                BookName="C#",
                AuthorName="Pavi",
                Availability=Availability.Damaged
        },
         new BookDetails
        {
            BookID=3,
                BookName="C#",
                AuthorName="Pavi",
                Availability=Availability.Issued
        },
         new BookDetails
        {
            BookID=4,
                BookName="C#",
                AuthorName="Pavi",
                Availability=Availability.Available
        },
        new BookDetails
        {
            BookID=5,
            BookName="html",
            AuthorName="Ragu",
            Availability=Availability.Damaged
        }

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