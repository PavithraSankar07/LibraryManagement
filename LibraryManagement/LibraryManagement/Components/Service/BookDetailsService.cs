using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Components.Models;

namespace LibraryManagement.Components.Service
{
    public class BookDetailsService
    {
     

        public List<BookDetails> GetBooks()
        {
            return ApplicationDBContext.books;
        }
        public bool AddBook(BookDetails newbook)
        {
            if (newbook != null)
            {
                if (ApplicationDBContext.books.Count != 0)
                {
                    newbook.BookID = ApplicationDBContext.books[ApplicationDBContext.books.Count - 1].BookID + 1;
                }
                else
                {
                    newbook.BookID = 1;
                }
                ApplicationDBContext.books.Add(newbook);
                return true;
            }
            return false;
        }
        public BookDetails GetbookbyID(int BookID)
        {
            BookDetails book = ApplicationDBContext.books.Find(u => u.BookID == BookID);
            return book;
        }
        public bool Delete(int book)
        {
            BookDetails book1 = ApplicationDBContext.books.Find(u => u.BookID == book);

            if (book1 != null)
            {
                ApplicationDBContext.books.Remove(book1);
                return true;
            }

            return false;
        }
        public bool EditBook(BookDetails book)
        {
            var book1 = ApplicationDBContext.books.Find(u => book.BookID == u.BookID);
            if (book1 != null)
            {
                book1.AuthorName = book.AuthorName;
                book1.Availability = book.Availability;
                book1.BookName = book.BookName;
                return true;

            }
            return false;
        }
    }
}