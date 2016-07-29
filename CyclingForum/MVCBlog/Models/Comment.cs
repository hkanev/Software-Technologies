using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using MVC_Blog.Models;

namespace MVCBlog.Models
{
    public class Comment
    {
        public Comment()
        {
            this.Date = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }


        [Required]
        public DateTime Date { get; set; }

        public string AuthorId { get; set; }
        public ApplicationUser Author { get; set; }

        public Post Post { get; set; }
    }
}