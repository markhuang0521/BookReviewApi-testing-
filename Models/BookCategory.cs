using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReview.Models
{
    public class BookCategory
    {
        public int BookId { get; set; }
        public int CateId { get; set; }
        public Book Book { get; set; }
        public Category Category { get; set; }

    }
}
