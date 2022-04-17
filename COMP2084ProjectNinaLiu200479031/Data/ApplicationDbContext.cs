using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using COMP2084ProjectNinaLiu200479031.Models;

namespace COMP2084ProjectNinaLiu200479031.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<COMP2084ProjectNinaLiu200479031.Models.FitnessCoach> FitnessCoach { get; set; }
        public DbSet<COMP2084ProjectNinaLiu200479031.Models.FitnessMembership> FitnessMembership { get; set; }
        public DbSet<COMP2084ProjectNinaLiu200479031.Models.FitnessProgram> FitnessProgram { get; set; }
        public DbSet<COMP2084ProjectNinaLiu200479031.Models.FitnessClientBooking> FitnessClientBooking { get; set; }
        public DbSet<COMP2084ProjectNinaLiu200479031.Models.FitnessScheduleManagement> FitnessScheduleManagement { get; set; }

#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public DbSet<Role> Roles { get; set; }
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
    }
}
