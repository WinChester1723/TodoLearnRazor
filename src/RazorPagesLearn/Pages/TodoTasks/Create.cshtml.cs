using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using RazorPagesLearn.Models;

namespace RazorPagesLearn.Pages_TodoTasks
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesLearn.Data.RazorPagesLearnContext _context;

        public CreateModel(RazorPagesLearn.Data.RazorPagesLearnContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TodoTask TodoTask { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Task == null || TodoTask == null)
            {
                return Page();
            }

            _context.Task.Add(TodoTask);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
