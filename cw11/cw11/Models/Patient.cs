using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Models
{
    public class Patient
    {

        [Required]
        [Key]
        public int IdPatient { get; set; }
        
        [Required]
        [MaxLength(100)]
        public String FirstName { get; set; }
        
        [Required]
        [MaxLength(100)]
        public String LastName { get; set; }
        
        [Required]
        public DateTime Birthdate { get; set; }
    }
}
