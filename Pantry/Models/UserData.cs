using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pantry.Models
{
    public class UserData
    {

        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
