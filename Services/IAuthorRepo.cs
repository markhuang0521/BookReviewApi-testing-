using BookReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReview.Services
{
    public interface IAuthorRepo
    {
        ICollection<Author> GetAuthors();
        Author GetAuthor(int authorId);
        ICollection<Author> GetAuthorsFromBook(int bookId);
        ICollection<Book> GetBooksFromAuthor(int authorId);
        bool AuthorExist(int authorId);

    }
}
