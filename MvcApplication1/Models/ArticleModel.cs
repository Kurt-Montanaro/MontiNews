using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class ArticleModel
    {
        [Display(Name = "Header")]
        [StringLength(50,MinimumLength = 3)]
        [Required]
        public string header { get; set; }

        [Display(Name = "Sub Header :")]
        [Required]
        public string subheader { get; set; }

        [Display(Name = "Category :")]
        [Required]
        public string category { get; set; }

        [Display(Name = "Username :")]
        public string username { get; set; }

        [Display(Name = "Upload Image :")]
        public HttpPostedFileBase imageUpload { get; set; }

        [Display(Name = "Article Content :")]
        [StringLength(512000)]
        [Required]
        public string content { get; set; }

        public DateTime timestamp { get; set; }
        public string imagename { get; set; }


    }
}