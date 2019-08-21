using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookReview.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private IReview _reviewRepository;
        public ReviewController(IReview reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        //api/reviews
        [HttpGet]
        public IActionResult getReviews()
        {
            var reviews = _reviewRepository.GetReviews();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(reviews);
        }

        //api/reviews/reviewId
        [HttpGet("{reviewId}")]
        public IActionResult getReview(int reviewId)
        {
            if (!_reviewRepository.ReviewExist(reviewId))
            {
                return NotFound();
            }
            var reviews = _reviewRepository.GetReview(reviewId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(reviews);
        }
        //api/reviews/books/bookid
        [HttpGet("books/{bookId}")]
        public IActionResult GetReviewOfBook(int bookId)
        {

            var reviews = _reviewRepository.GetReviewOfBook(bookId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(reviews);
        }

    }
}