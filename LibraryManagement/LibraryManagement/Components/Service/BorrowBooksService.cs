using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Components.Models;
using LibraryManagement.Components.Pages;

namespace LibraryManagement.Components.Service
{
    public class BorrowDetailsService
    {
        private readonly UserService _userService;
        private readonly BookDetailsService _bookService;
        public BorrowDetailsService(UserService userService, BookDetailsService bookService)
        {
            _userService = userService;
            _bookService = bookService;
        }

        public static List<BorrowDetails> borrows = new();
        // get book count

        public int BookCount(int UserID)
        {
            int bookcount = 0;
            foreach (BorrowDetails borrow in borrows)
            {
                if (UserID == borrow.UserID)
                {
                    bookcount++;
                }
            }
            return bookcount;
        }
        // get book add
        // book count

        public int AddBorrowBook(int bookid, string maildid)
        {
            var currentUser = _userService.GetMailID(maildid);
            if (currentUser == null)
            {
                return 3;
            }

            var currentBook = _bookService.GetbookbyID(bookid);
            if (currentBook == null)
            {
                return 4;
            }
            Console.WriteLine(currentBook);
            Console.WriteLine(currentUser);

            int bookcount = 0;
            foreach (BorrowDetails borrow in borrows)
            {
                if (currentUser.UserID == borrow.UserID)
                {
                    bookcount++;
                }
            }
            if (bookcount >= 3)
            {
                return 0;
            }
            else
            {
                if (currentBook.Availability == "Available")
                {
                    ApplicationDBContext.borrows.Add(new BorrowDetails()
                    {
                        BookID = bookid,
                        BorrowID = ApplicationDBContext.borrows[ApplicationDBContext.borrows.Count - 1].BorrowID + 1,
                        BorrowedDate = DateTime.Now,
                        BookingStatus = BookingStatus.Borrowed
                    });
                    currentBook.Availability = "NotAvailable";
                    return 1;
                }

            }
            return 2;

        }

        // public bool AddBorrowBook(BorrowDetails borrowbook)
        // {
        //     if (borrowbook != null)
        //     {
        //         borrowbook.BorrowID = borrows[borrows.Count - 1].BorrowID + 1;
        //         borrows.Add(borrowbook);
        //         return true;
        //     }
        //     return false;
        // }
        // userdetails 
        public List<BorrowDetails> GetUserDetails(int userid)
        {
            List<BorrowDetails> borrowDetails = new();
            foreach (BorrowDetails borrow in borrows)
            {
                if (userid == borrow.UserID)
                {
                    borrowDetails.Add(borrow);
                }
            }
            return borrowDetails;
        }
        // get all book
        public List<BorrowDetails> GetAllBooks()
        {
            return ApplicationDBContext.borrows;
        }
        public BorrowDetails GetIDByBorrow(int borrowid)
        {
            var borrow = ApplicationDBContext.borrows.Find(u => u.BorrowID == borrowid);
            return borrow;
        }
        public int Cancel(int borrowid)
        {
            var currentbookcancelid = GetIDByBorrow(borrowid);
            var bookid = _bookService.GetbookbyID(currentbookcancelid.BookID);
            if (currentbookcancelid.BookingStatus == BookingStatus.Borrowed)
            {
                currentbookcancelid.BookingStatus = BookingStatus.Returned;
                bookid.Availability = "Available";
                return 0;
            }
            return 1;

        }

    }
}