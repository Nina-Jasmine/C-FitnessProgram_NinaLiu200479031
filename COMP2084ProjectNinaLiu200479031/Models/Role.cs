using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COMP2084ProjectNinaLiu200479031.Models
{
    public class Role
    {

        [Key]
         public string Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string RoleName { get; set; }
    }
}
