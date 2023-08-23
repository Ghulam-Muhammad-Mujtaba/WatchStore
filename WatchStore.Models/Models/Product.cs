using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchStore.Models.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ModelNo { get; set; } //changed to string
        [Required]
        public double Price { get; set; }
        [Required]
        public double DiscountedPrice { get; set; }
        [Required]
        public string Warrenty { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [ValidateNever]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        [ValidateNever]
        public Brand Brand { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [Required]
        [Display(Name ="Band")]
        public int BandId { get; set; }
        [ForeignKey("BandId")]
        [ValidateNever]
        public Band Band { get; set;}

        [Required]
        [Display(Name = "Dial")]
        public int DialId { get; set; }
        [ForeignKey("DialId")]
        [ValidateNever]
        public Dial Dial { get; set; }

    }
}
