using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminInternPort.Models
{
    public class Instructors
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string UserName { get; set; }
        public bool InstructorEmployer { get; set; }
        public string Major { get; set; }
        [ForeignKey("Program")]
        public int ProgramId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
