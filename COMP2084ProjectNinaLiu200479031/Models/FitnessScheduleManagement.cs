using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP2084ProjectNinaLiu200479031.Models
{
    public class FitnessScheduleManagement
    {
        [Key]
        [Column(Order = 0, TypeName = "int")]
        public int ScheduleID { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "int")]     
        public int BookingID { get; set; }
        [ForeignKey("BookingID")]
        [Display(Name = "Your Booked Program ID")]
        public FitnessClientBooking FitnessClientBooking { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Column(Order = 2, TypeName = "datetime")]
        public DateTime ScheduledTime { get; set; }

        [Required]
        [Column(Order = 3, TypeName = "tinyint")]
        public int Hours { get; set; }

        [Column(Order = 4, TypeName = "bit")]
        public Boolean IsAttend { get; set; }

    }
}