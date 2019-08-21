using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReview.Models
{
    public class Review
    {
        [Key]
        public int id { get; set; }
        // 1-5
        public int Rating { get; set; }
        public string Headline { get; set; }
        public string ReviewText { get; set; }
        public virtual Reviewer Reviewer { get; set; }
        public virtual Book Book { get; set; }
    }
}
