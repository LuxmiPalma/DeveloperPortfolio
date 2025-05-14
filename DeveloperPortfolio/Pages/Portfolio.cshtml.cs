using DeveloperPortfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeveloperPortfolio.Pages
{
    public class PortfolioModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public List<Project> Projects { get; set; } = new();

        public PortfolioModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public void OnGet()
        {
        }
    }
}
