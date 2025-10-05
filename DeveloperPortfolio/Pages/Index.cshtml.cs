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
        private readonly IWebHostEnvironment _env;

        public IndexModel(ILogger<IndexModel> logger, IProjectService projectService, IWebHostEnvironment env)
        {
            _logger = logger;
            _projectService = projectService;
            _env = env;
        }

        public List<ProjectDTO> Projects { get; set; } = new();

        [BindProperty]
        public ContactForm ContactForm { get; set; } = new();

        [TempData]
        public string? ContactSuccessMessage { get; set; }

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(ContactSuccessMessage))
                ContactForm = new ContactForm();

            Projects = await _projectService.GetProjectsAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                var msg = new MailMessage
                {
                    Subject = ContactForm.Subject,
                    Body = $"Name: {ContactForm.Name}\nEmail: {ContactForm.Email}\n\n{ContactForm.Message}",
                    IsBodyHtml = false
                };

                msg.From = new MailAddress("luxmi.palma@gmail.com", "Portfolio Contact");
                msg.To.Add("luxmi.palma@gmail.com");

                if (MailAddress.TryCreate(ContactForm.Email, out var replyTo))
                    msg.ReplyToList.Add(replyTo);

                using var smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,                 
                    UseDefaultCredentials = false,    
                    Credentials = new NetworkCredential(
                        "luxmi.palma@gmail.com",
                        "yrwakgajlwmoudwr"           
                    ),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Timeout = 10000
                };

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                await smtp.SendMailAsync(msg);

                ContactSuccessMessage = "Thank you! Your message has been sent.";
                return Redirect("/#contact");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email.");
                ModelState.AddModelError(string.Empty, "Failed to send message. Please try again later.");
                return Page();
            }
        }
    }
}
