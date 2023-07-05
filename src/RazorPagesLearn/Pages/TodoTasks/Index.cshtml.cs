using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IList<TodoTask> TodoTask { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Title { get; set; }

        //[BindProperty(SupportsGet = true)]
        //public string? TaskDescription { get; set; }


        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            //IQueryable<string> descriptionQuery = from d in _context.Task
            //                                      orderby d.Description
            //                                      select d.Description;

            var tasks = from t in _context.Task
                        select t;

            if (!string.IsNullOrEmpty(SearchString))
            {
                tasks = tasks.Where(s => s.Title.Contains(SearchString));
            }

            //if (!string.IsNullOrEmpty(TaskDescription))
            //{
            //    tasks = tasks.Where(x => x.Description == TaskDescription);
            //}

            
            TodoTask = await tasks.ToListAsync();
            #region OldCode
            //if (_context.Task != null)
            //{
            //    TodoTask = await _context.Task.ToListAsync();
            //} 
            #endregion
        }
    }
}
