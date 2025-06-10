using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class ApplicationDBContext
    {

        public static List<UserDetails> Users { get; } = new List<UserDetails>
        {

                new UserDetails
                {
                    UserID = "1",
                    UserName = "Pavi",
                    PhoneNumber = 9876543210,
                    Gender = Gender.Female,
                    Department = "Maths",
                    MailID = "pavi@gmail.com",
                    Password = "123",
                    WalletBalance = 150,

                },
                new UserDetails
                {
                    UserID = "2",
                    UserName = "ragu",
                    PhoneNumber = 9123456789,
                    Gender = Gender.Male,
                    Department = "ECE",
                    MailID = "ragu@gmail.com",
                    Password = "123",
                    WalletBalance = 75,
                }

            };

        public static List<BookDetails> books = new List<BookDetails>()
        {
            new BookDetails { BookID = "BID1001", BookName = "Star", AuthorName = "Pavi", Availability = Availability.Available },
            new BookDetails { BookID = "BID1002", BookName = "1984", AuthorName = "Ragu", Availability = Availability.Issued },
            new BookDetails { BookID = "BID1003", BookName = "EI", AuthorName = "Suba", Availability = Availability.Available }
        };
        public static List<BorrowDetails> borrowList = new List<BorrowDetails>()
        {
            new BorrowDetails{BorrowID = "LB2000", BookID="BID1002", BorrowedDate = DateTime.Parse("11/11/1111"), BookingStatus=BookingStatus.Borrowed, PaidFineAmount=0, UserID="2"}
        };
    }
}
