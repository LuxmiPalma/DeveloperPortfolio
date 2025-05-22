using DeveloperPortfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;
using System.Net;

namespace DeveloperPortfolio.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public ContactForm Form { get; set; } = new();

        [TempData]
        public string? ContactSuccess { get; set; }

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(ContactSuccess))
            {
                Form = new ContactForm(); 
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            try
            {
                // Send email (simple SMTP setup)
                var from = new MailAddress("your-email@example.com", "Luxmi's Portfolio");
                var to = new MailAddress("luxmi.palma@gmail.com");

                var message = new MailMessage(from, to)
                {
                    Subject = Form.Subject,
                    Body = $"From: {Form.Name} ({Form.Email})\n\n{Form.Message}"
                };

                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("luxmi.palma@.com", "hfmv jpyx gehz jmqd");
                    smtp.EnableSsl = true;
                    smtp.Send(message);
                }

                ContactSuccess = "Thank you! Your message has been sent.";
                return RedirectToPage();

            }
            catch (Exception )
            {
                ModelState.AddModelError(string.Empty, " Failed to send message. Please try again later.");
                return Page();
            }

           
        }
    }
}
