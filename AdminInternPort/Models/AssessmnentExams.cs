using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminInternPort.Models
{
    public class AssessmnentExams
    {
        [Key]
        public int AssessmentId { get; set; }
        [Url]
        public string ExamUrl { get; set; }
        [ForeignKey("Program")]
        public int ProgramId { get; set; }
    }
}
