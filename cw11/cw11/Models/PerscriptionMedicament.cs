using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Models
{
    public class PrescriptionMedicament
    {

        [Key]
        [Required]
        [ForeignKey("Medicament")]
        public int IdMedicament { get; set; }
        
        [Required]
        [Key]
        [ForeignKey("Prescription")]
        public int IdPrescription { get; set; }

        public int? Dose { get; set; }
        
        [Required]
        [MaxLength(100)]
        public String Details { get; set; }
    }
}
