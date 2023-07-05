using System.ComponentModel.DataAnnotations;

namespace RazorPagesLearn.Models
{
    public class TodoTask
    {
        public int Id { get; set; }

        [Display(Name = "Task Title")]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Display(Name = "Task Description")]
        public string? Description { get; set; }

        [Display(Name = "Task Create Date")]
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
    }
}
