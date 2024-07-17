using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.classes
{
    public class Discussion
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public string User { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

    }
}
