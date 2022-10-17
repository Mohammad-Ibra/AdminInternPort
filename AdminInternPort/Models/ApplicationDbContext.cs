using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminInternPort.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Program> Program { get; set; }
       
        public DbSet<AssessmnentExams> Exams { get; set; }
        public DbSet<Instructors> Instructors { get; set; }
        public DbSet<Interns> Interns { get; set; }
  
    }
}
