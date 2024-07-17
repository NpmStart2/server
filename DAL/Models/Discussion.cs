using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Discussion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }


        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime LastModifiedDate { get; set; }
    }
}
