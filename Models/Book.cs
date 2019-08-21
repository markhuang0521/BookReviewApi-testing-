using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReview.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime ? PulishTime { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public ICollection<BookAuthor>  BookAuthors { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }

    }
}
