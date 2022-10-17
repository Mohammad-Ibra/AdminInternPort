using AdminInternPort.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminInternPort.Controllers
{
    [Route("api/programs")]
    [ApiController]
    public class ProgramController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProgramController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Program.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var Program = await _db.Program.FirstOrDefaultAsync(u => u.Id == id);
            if (Program == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _db.Program.Remove(Program);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful!" });
        }
    }
}
