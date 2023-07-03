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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesLearn.Data.RazorPagesLearnContext _context;

        public DetailsModel(RazorPagesLearn.Data.RazorPagesLearnContext context)
        {
            _context = context;
        }

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
    }
}
