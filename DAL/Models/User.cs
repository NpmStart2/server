using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        //[MaxLength(50)] // Adjust maximum length as needed
        public required string Username { get; set; }

        [Required]
        //[MaxLength(100)] // Adjust maximum length as needed
        public string Email { get; set; }

        [Required]
        //[MaxLength(50)] // Adjust maximum length as needed
        public string Password { get; set; }
    }
}
