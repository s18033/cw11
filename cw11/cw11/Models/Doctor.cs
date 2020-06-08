using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Models
{
    public class Doctor
    {
        [Key]
        [Required]
        public int IdDoctor { get; set; }
        
        [Required]
        [MaxLength(100)]
        public String FirstName { get; set; }
        
        [Required]
        [MaxLength(100)]
        public String LastName { get; set; }
        
        [Required]
        [MaxLength(100)]
        public String Email { get; set; }

    }
}
