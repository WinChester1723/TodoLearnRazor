using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesLearn.Data;
using RazorPagesLearn.Models;

namespace RazorPagesLearn.Pages_TodoTasks
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesLearn.Data.RazorPagesLearnContext _context;

        public DeleteModel(RazorPagesLearn.Data.RazorPagesLearnContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TodoTask TodoTask { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }

            var todotask = await _context.Task.FirstOrDefaultAsync(m => m.Id == id);

            if (todotask == null)
            {
                return NotFound();
            }
            else 
            {
                TodoTask = todotask;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }
            var todotask = await _context.Task.FindAsync(id);

            if (todotask != null)
            {
                TodoTask = todotask;
                _context.Task.Remove(TodoTask);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
