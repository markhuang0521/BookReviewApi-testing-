using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReview.Models
{
    public class Category
    {
        [Key]
        public int CateId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BookCategory> BookCategories { get; set; }

    }
}
