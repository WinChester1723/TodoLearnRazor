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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesLearn.Data.RazorPagesLearnContext _context;

        public IndexModel(RazorPagesLearn.Data.RazorPagesLearnContext context)
        {
            _context = context;
        }

        public IList<TodoTask> TodoTask { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Task != null)
            {
                TodoTask = await _context.Task.ToListAsync();
            }
        }
    }
}
