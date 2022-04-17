using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace COMP2084ProjectNinaLiu200479031.Models
{
    public class FitnessCoach
    {
        [Key]
        [Column(Order = 0, TypeName = "int")]
        public int CoachID { get; set; }
        [Required]
        [Display(Name = "Coach Name")]
        [Column(Order = 1, TypeName = "nvarchar(50)")]
        public string CoachName { get; set; }

        [Required]
        [Column(Order = 2, TypeName = "nvarchar(50)")]
        public string Major { get; set; }

        [Required]
        [Column(Order = 3, TypeName = "nvarchar(MAX)")]
        [StringLength(250, ErrorMessage = "Max length 250")]
        public string Introduction { get; set; }

        [StringLength(150, ErrorMessage = "Error: Max length 150")]
        [Column(Order = 4, TypeName = "nvarchar(150)")]
        public string PhotoLink { get; set; }

        public ICollection<FitnessProgram> FitnessProgram { get; set; }
    }
}
