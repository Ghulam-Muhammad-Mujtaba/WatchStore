using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchStore.Models.Models
{
    public class Band
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Material { get; set; }
        [Required]
        [Range(165, 200, ErrorMessage = "Band length must be between 165mm to 200mm")]
        public int Length { get; set; }
        [Required]
        [Range(16, 24, ErrorMessage = "Dial diameter must be between 16mm to 24mm")]
        public int Width{ get; set; }
        [Required]
        public string Color { get; set; }
    }
}
