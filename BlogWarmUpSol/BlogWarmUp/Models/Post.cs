using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWarmUp.Models
{
    public class Post
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set;}
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public bool isDeleted { get; set;}

    }
}
