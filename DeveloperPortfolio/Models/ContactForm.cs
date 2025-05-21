using System.ComponentModel.DataAnnotations;

namespace DeveloperPortfolio.Models
{
    public class ContactForm
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Subject is required.")]
        public string Subject { get; set; } = null!;

        [Required(ErrorMessage = "Message is required.")]
        public string Message { get; set; } = null!;
    }
}
