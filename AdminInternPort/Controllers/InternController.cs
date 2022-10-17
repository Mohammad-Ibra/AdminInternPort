using AdminInternPort.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminInternPort.Controllers
{
        [Route("api/interns")]
        [ApiController]
        public class InternController : Controller
        {
            private readonly ApplicationDbContext _db;

            public InternController(ApplicationDbContext db)
            {
                _db = db;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                return Json(new { data = await _db.Interns.ToListAsync() });
            }

            [HttpDelete]
            public async Task<IActionResult> Delete(int id)
            {
                var Intern = await _db.Interns.FirstOrDefaultAsync(u => u.Id == id);
                if (Intern == null)
                {
                    return Json(new { success = false, message = "Error while deleting" });
                }
                _db.Interns.Remove(Intern);
                await _db.SaveChangesAsync();
                return Json(new { success = true, message = "Delete successful!" });
            }
        }
}
