using AdminInternPort.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminInternPort.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Instructors.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var User = await _db.Instructors.FirstOrDefaultAsync(u => u.Id == id);
            if (User == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _db.Instructors.Remove(User);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful!" });
        }
    }
}
