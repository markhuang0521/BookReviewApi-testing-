using BookReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReview.Services
{
   public interface ICateRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int cateId);
        ICollection<Category> GetCategoriesOfBook(int bookId);
        ICollection<Book> GetBooksOfCategory(int cateId);

        bool CategoryExist(int cateId);
    }
}
