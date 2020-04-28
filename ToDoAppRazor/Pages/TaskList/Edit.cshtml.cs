using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorRagesTutorial.Model;

namespace RazorRagesTutorial.Pages.TaskList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Model.Task Task { get; set; }

        public async System.Threading.Tasks.Task OnGet(int id)
        {
            Task = await _db.Task.FindAsync(id);
        }

        public async System.Threading.Tasks.Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var TaskFromDb = await _db.Task.FindAsync(Task.Id);
                TaskFromDb.Name = Task.Name;
                TaskFromDb.Description = Task.Description;
                TaskFromDb.Status = Task.Status;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}