using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookReview.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookReview
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICateRepository _cateRepository;
        public CategoryController(ICateRepository cateRepository)
        {
            _cateRepository = cateRepository;
        }
        //api/Category
        [HttpGet]
        public IActionResult getCategories()
        {
            var categories = _cateRepository.GetCategories();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(categories);
        }
        [HttpGet("{cateId}")]
        public IActionResult getCategory(int cateId)
        {
            if (!_cateRepository.CategoryExist(cateId))
            {
                return NotFound();
            }
            var categories = _cateRepository.GetCategory(cateId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(categories);
        }
        //api/category/books/bookid
        [HttpGet("books/{bookId}")]
        public IActionResult GetCategoriesOfBook(int bookId)
        {
            
            var categories = _cateRepository.GetCategoriesOfBook(bookId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(categories);
        }

        //api/categories/cateid
        [HttpGet("{cateId}/books")]
        public IActionResult GetBooksOfCategory(int cateId)
        {

            var books = _cateRepository.GetBooksOfCategory(cateId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(books);
        }
    }
}