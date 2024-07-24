using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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


        public int? UserId { get; set; }
        [ForeignKey("UserId")]

        public virtual User User { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime LastModifiedDate { get; set; }
    }
}
