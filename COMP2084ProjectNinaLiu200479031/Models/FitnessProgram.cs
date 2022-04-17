using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP2084ProjectNinaLiu200479031.Models
{
    public enum PeriodEnum
    {
        Month, Year, DropIn
    }
    public class FitnessProgram
    {
        [Key]
        [Column(Order = 0, TypeName = "int")]
        public int ProgramID { get; set; }
        [Required]
        [Display(Name = "Fitness Program Name")]
        [Column(Order = 1, TypeName = "nvarchar(50)")]
        public string ProgramName { get; set; }
        [Required]
        [Display(Name = "Program Description")]
        [Column(Order = 2, TypeName = "nvarchar(MAX)")]
        [StringLength(250, ErrorMessage = "Error: Max length 250")]
        public string ProgramDescription { get; set; }

        [Column(Order = 3, TypeName = "int")]
        [Display(Name = "Coach Name")]
        public int CoachID { get; set; }
        [ForeignKey("CoachID")]
        public FitnessCoach Coach { get; set; }

        [Required]
        [Column(Order = 4, TypeName = "decimal(6,2)")]
        public double Pricing { get; set; }
        [Column(Order = 5, TypeName = "bit")]
        public Boolean ApplyVouchers { get; set; }

        [Required]
        [Column(Order = 6, TypeName = "nvarchar(10)")]
        [EnumDataType(typeof(PeriodEnum))]
        public PeriodEnum Period { get; set; }
        public ICollection<FitnessClientBooking> FitnessClientBooking { get; set; }
    }
}