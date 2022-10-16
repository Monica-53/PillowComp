using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PillowComp.Models
{
    public class Pillow
    {
        
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ManufactureDate { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Colour { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Size { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

    }
}

