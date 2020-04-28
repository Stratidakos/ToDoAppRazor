using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorRagesTutorial.Model;

namespace RazorRagesTutorial.Pages.TaskList
{
    public class AddModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public AddModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Model.Task Task { get; set; }

        public void OnGet()
        {

        }

        public async System.Threading.Tasks.Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Task.Status = "New";
                await _db.Task.AddAsync(Task);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}