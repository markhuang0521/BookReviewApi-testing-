using BookReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReview.Services
{
    public  interface IReviewerRepo
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int reviewerId);
        ICollection<Review> GetReviewFromReviwers(int reviewerId);
        Reviewer GetReviewerFromReview(int reviewId);
        bool ReviewerExist(int reviewerId);


    }
}
