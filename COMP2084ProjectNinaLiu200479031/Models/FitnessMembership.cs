using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP2084ProjectNinaLiu200479031.Models
{
    public class FitnessMembership
    {
        [Key]
        [Column(Order = 0, TypeName = "int")]
        public int MembershipID { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        [Column(Order = 1, TypeName = "nvarchar(50)")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Phone Number Required!")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Column(Order = 2, TypeName = "nvarchar(15)")]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        [Column(Order = 3, TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        [Column(Order = 4, TypeName = "bit")]
        public Boolean IsVIP { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Column(Order = 5, TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(Order = 6, TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime LastFollowUp { get; set; }

        public ICollection<FitnessClientBooking> FitnessClientBooking { get; set; }
    }
}