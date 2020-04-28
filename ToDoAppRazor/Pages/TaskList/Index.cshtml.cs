using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorRagesTutorial.Model;
using Task = RazorRagesTutorial.Model.Task;

namespace RazorRagesTutorial.Pages.TaskList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Task> Tasks { get; set; }
        public async System.Threading.Tasks.Task OnGet()
        {
            Tasks = await _db.Task.ToListAsync();
        }

        public async System.Threading.Tasks.Task<IActionResult> OnPostDelete(int id)
        {
            var task = await _db.Task.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            _db.Task.Remove(task);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}