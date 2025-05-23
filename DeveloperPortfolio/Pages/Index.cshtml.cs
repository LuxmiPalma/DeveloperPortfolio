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
        [TempData]
        public string? ContactSuccessMessage { get; set; }

      
        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(ContactSuccessMessage))
            {
                ContactForm = new ContactForm();
            }
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
                mailMessage.To.Add("luxmi.palma@gmail.com"); 
                mailMessage.From = new MailAddress(ContactForm.Email); 
                mailMessage.Subject = ContactForm.Subject;
                mailMessage.Body = $"Name: {ContactForm.Name}\nEmail: {ContactForm.Email}\nMessage: {ContactForm.Message}";

                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(
                        ("luxmi.palma@gmail.com"),
                        ("hfmv jpyx gehz jmqd")
                    );
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                    await smtpClient.SendMailAsync(mailMessage);
                }

                ContactSuccessMessage = "Thank you! Your message has been sent.";
                return Redirect("/#contact");
            }
            catch (Exception ex)
            {
                TempData["ShowToast"] = false;
                TempData["ErrorMessage"] = "Could not send message.";
                _logger.LogError(ex, "Error sending email.");
            }

            return Page();
        }
    }
}