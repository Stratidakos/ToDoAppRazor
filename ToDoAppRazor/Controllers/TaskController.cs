using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorRagesTutorial.Model;

namespace RazorRagesTutorial.Controllers
{
    [Route("api/Task")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TaskController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data =await _db.Task.ToListAsync() });
        }

        
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var taskFromDb = await _db.Task.FirstOrDefaultAsync(u => u.Id == id);
            if (taskFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Task.Remove(taskFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}