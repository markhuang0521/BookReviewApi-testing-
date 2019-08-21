using BookReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReview.Services
{
    public class ReviewerRepo : IReviewerRepo
    {
        private BookDbContext _context;

        public ReviewerRepo(BookDbContext context)
        {
            _context = context;
        }

        public Reviewer GetReviewer(int reviewerId)
        {
            return _context.Reviewers.Where(r => r.ReviewerId == reviewerId).FirstOrDefault();
        }

        public Reviewer GetReviewerFromReview(int reviewId)
        {
            var reviewerId = _context.Reviews.Where(r => r.id == reviewId).Select(r => r.Reviewer.ReviewerId).FirstOrDefault();
            return _context.Reviewers.Where(r => r.ReviewerId == reviewerId).FirstOrDefault();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _context.Reviewers.ToList();
        }

        public ICollection<Review> GetReviewFromReviwers(int reviewerId)
        {
            return _context.Reviews.Where(r => r.Reviewer.ReviewerId == reviewerId).ToList();

        }

        public bool ReviewerExist(int reviewerId)
        {
            return _context.Reviewers.Any(r => r.ReviewerId == reviewerId);
        }
    }
}
