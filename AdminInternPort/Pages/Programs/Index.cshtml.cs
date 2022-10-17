using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminInternPort.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AdminInternPort.Pages.Programs
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Models.Program> Programs { get; set; }
        public async Task OnGet()
        {
            Programs = await _db.Program.ToListAsync();
        }
    }
}
