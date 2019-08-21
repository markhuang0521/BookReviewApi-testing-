using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookReview.Models;

namespace BookReview.Services
{
    public class ReviewRepository 
    {
        private BookDbContext _context;
        public ReviewRepository(BookDbContext context)
        {
            _context = context;
        }
        public Book GetBookOfReview(int reviewId)
        {
            var bookId = _context.Reviews.Where(r => r.id == reviewId).Select(b => b.Book.BookId).FirstOrDefault();
            return _context.Books.Where(b => b.BookId == bookId).FirstOrDefault();
        }

        public Review GetReview(int reviewId)
        {
            return _context.Reviews.Where(r => r.id == reviewId).FirstOrDefault();
        }

        public ICollection<Review> GetReviewOfBook(int bookId)
        {
            return _context.Reviews.Where(b => b.Book.BookId == bookId).ToList();
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();

        }

        public bool ReviewExist(int reviewId)
        {
            return _context.Reviews.Any(r => r.id == reviewId);
        }
    }
}
