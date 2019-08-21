using BookReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReview.Services
{
    public interface IBookRepo
    {
        ICollection<Book> GetBooks();
        Book GetBook(int bookId);
        Book GetBook(string ISBN);

        bool BookExist(int bookId);
        bool BookExist(string ISBN);


    }
}
