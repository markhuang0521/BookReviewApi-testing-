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
    public class ReviewerController : ControllerBase
    {
        private IReviewerRepo _reviewerRepo;
        public ReviewerController(IReviewerRepo reviewerRepo)
        {
            _reviewerRepo = reviewerRepo;
        }

        [HttpGet]
         public IActionResult getReviewers()
        {
           var reviewers=  _reviewerRepo.GetReviewers();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            return Ok(reviewers);
        }

        [HttpGet("{reviewerId}")]
         public IActionResult getReviewer(int reviewerId)
        {
           var reviewers=  _reviewerRepo.GetReviewers();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            return Ok(reviewers);
        }


    }
}