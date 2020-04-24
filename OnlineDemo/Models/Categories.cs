using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineDemo.Models
{
    public class Categories
    {
        [Key]
        public int? CategoryId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name ="Category Name")]
        public string CategoryName { get; set; }
        public bool IsDeleted { get; set; }
    }
}