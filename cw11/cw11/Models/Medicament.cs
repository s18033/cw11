using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Models
{
    public class Medicament
    {

        [Key]
        [Required]
        public int IdMedicament { get; set; }
        
        [Required]
        [MaxLength(100)]
        public String Name { get; set; }
        
        [Required]
        [MaxLength(100)]
        public String Description { get; set; }
        
        [Required]
        [MaxLength(100)]
        public String Type { get; set; }
    }
}
