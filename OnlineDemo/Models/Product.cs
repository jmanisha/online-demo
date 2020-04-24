using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineDemo.Models
{
    public class Product
    {
        [Key]
        public int? ProductId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }

        public Categories Categories { get; set; }

        [Display(Name="Category Type")]
        [Required]
        public int CategoryId { get; set; }


    }
}