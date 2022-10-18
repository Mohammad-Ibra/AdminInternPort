using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminInternPort.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AdminInternPort.Pages.Users
{
    [Authorize]
    public class Index1Model : PageModel
    {
        private ApplicationDbContext _db;

        public Index1Model(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Models.Instructors Instructor { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            Instructor = new Models.Instructors();
            if (id == null)
            {
                return Page();
            }
            Instructor = await _db.Instructors.FirstOrDefaultAsync(u => u.Id == id);
            if (Instructor == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Instructor.Id == 0)
                {
                    _db.Instructors.Add(Instructor);
                }
                else
                {
                    _db.Instructors.Update(Instructor);
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage("Index");
        }
    }
}
