using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DeveloperPortfolio.Models.DTO;
using DeveloperPortfolio.Services;
using DeveloperPortfolio.Models;
using System.Net.Mail;
using System.Net;




namespace DeveloperPortfolio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProjectService _projectService;


        public IndexModel(ILogger<IndexModel> logger, IProjectService projectService)
        {
            _logger = logger;
            _projectService = projectService;

        }
        public List<ProjectDTO> Projects { get; set; } = new();


        [BindProperty]
        public ContactForm ContactForm { get; set; } = new();
        [BindProperty(SupportsGet = false)]
        public string? ContactSuccessMessage { get; set; }


        public async Task OnGetAsync()
        {
            Projects = await _projectService.GetProjectsAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var mailMessage = new MailMessage();
                mailMessage.To.Add("your-real-email@gmail.com"); // ? Your email
                mailMessage.From = new MailAddress(ContactForm.Email); // ?? Visitor's email
                mailMessage.Subject = ContactForm.Subject;
                mailMessage.Body = $"Name: {ContactForm.Name}\nEmail: {ContactForm.Email}\nMessage: {ContactForm.Message}";

                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(
                        Environment.GetEnvironmentVariable("EMAIL_USERNAME"),
                        Environment.GetEnvironmentVariable("EMAIL_PASSWORD")
                    );
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                    await smtpClient.SendMailAsync(mailMessage);
                }

                TempData["ShowToast"] = true; // ? for success toast
            }
            catch (Exception ex)
            {
                TempData["ShowToast"] = false;
                TempData["ErrorMessage"] = "Could not send message.";
                _logger.LogError(ex, "Error sending email.");
            }

            return RedirectToPage("/Index"); // Reload page to show toast
        }
    }
}