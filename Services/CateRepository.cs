using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookReview.Models;

namespace BookReview.Services
{
    public class CateRepository : ICateRepository
    {
        private BookDbContext _context;
        public CateRepository(BookDbContext context)
        {
            _context = context;
        }
        public bool CategoryExist(int cateId)
        {
            return _context.Categories.Any(c => c.CateId == cateId);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.OrderBy(c=>c.Name).ToList();
        }

        public Category GetCategory(int cateId)
        {
            return _context.Categories.Where(c => c.CateId==cateId).FirstOrDefault();

        }

        public ICollection<Category> GetCategoriesOfBook(int bookId)
        {
            return _context.BookCategories.Where(b => b.BookId == bookId).Select(b => b.Category).ToList();
        }

        public ICollection<Book> GetBooksOfCategory(int cateId)
        {
            return _context.BookCategories.Where(c => c.CateId == cateId).Select(b => b.Book).ToList();
        }
    }
}
