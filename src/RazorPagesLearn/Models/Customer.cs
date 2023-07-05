using System.ComponentModel.DataAnnotations;

namespace RazorPagesLearn.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}