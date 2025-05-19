using DeveloperPortfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using DeveloperPortfolio.Models.DTO;

namespace DeveloperPortfolio.Pages
{
    public class PortfolioModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public List<ProjectDTO> Projects { get; set; } = new();

        public PortfolioModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7029/api/Projects/dto");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Projects = JsonSerializer.Deserialize<List<ProjectDTO>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new();
                Console.WriteLine("Projects loaded: " + Projects.Count);
            }
            else
            {
                Console.WriteLine("Failed to load projects. Status: " + response.StatusCode);
            }
        }
        
    }
}
