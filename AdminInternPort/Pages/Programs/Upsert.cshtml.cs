using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminInternPort.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AdminInternPort.Pages.Programs
{
    [Authorize]
    public class UpsertModel : PageModel
    {
        private ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Models.Program Program { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            Program = new Models.Program();
            if (id == null)
            {
                return Page();
            }
            Program = await _db.Program.FirstOrDefaultAsync(u => u.Id == id);
            if (Program == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Program.Id == 0)
                {
                    _db.Program.Add(Program);
                }
                else
                {
                    _db.Program.Update(Program);
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage("Index");
        }
      
    }
}
