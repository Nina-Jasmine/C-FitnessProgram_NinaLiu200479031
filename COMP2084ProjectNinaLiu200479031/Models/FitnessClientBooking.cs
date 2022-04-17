using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace COMP2084ProjectNinaLiu200479031.Models
{
    
    public class FitnessClientBooking
    {
        [Key]
        [Column(Order = 0, TypeName = "int")]
        public int BookingID { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "int")]
        [Display(Name = "Program Name")]
        public int ProgramID { get; set; }
        [ForeignKey("ProgramID")]
        public FitnessProgram Program { get; set; }

        [Required]
        [Column(Order = 2, TypeName = "int")]
        public int MembershipID { get; set; }
        [ForeignKey("MembershipID")]
        public FitnessMembership Membership { get; set; }

        [Column(Order = 3, TypeName = "nvarchar(50)")]
        public string Notes { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(Order = 4, TypeName = "date")]
        public DateTime StartDate { get; set; }

        public ICollection<FitnessScheduleManagement> FitnessScheduleManagements { get; set; }
    }
}
