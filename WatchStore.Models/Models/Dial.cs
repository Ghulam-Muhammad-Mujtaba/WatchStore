using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchStore.Models.Models
{
    public class Dial
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Material { get; set; }
        [Required]
        [Range(20,50, ErrorMessage = "Dial diameter must be between 20mm to 50mm")]
        public int Diameter { get; set; }
        [Required]
        [Range(6, 18, ErrorMessage = "Dial thickness must be between 6mm to 18mm")]
        public int Thickness { get; set; }
    }
}
