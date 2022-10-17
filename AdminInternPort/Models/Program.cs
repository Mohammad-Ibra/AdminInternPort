using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminInternPort.Models
{
    
    public class Program
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        [Url]
        public string GoogleClassroomCode { get; set; }
        public int MyProperty { get; set; }
    }

    
    public class Interns
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public string University { get; set; }
        public string Major { get; set; }
        public DateTime GraduationDate { get; set; }
        [ForeignKey("Program")]
        public int ProgramId { get; set; }
        public DateTime CreationDate { get; set; }
        public bool ValidEmail { get; set; }
    }
}
