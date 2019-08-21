using BookReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReview.Services
{
    public interface IReview
    {
        ICollection<Review> GetReviews();
        Review GetReview(int reviewId);

        ICollection<Review> GetReviewOfBook(int bookId);

        Book GetBookOfReview(int reviewId);
        bool ReviewExist(int reviewId);



    }
}
