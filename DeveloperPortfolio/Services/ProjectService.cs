using System.Text.Json;
using DeveloperPortfolio.Models.DTO;

namespace DeveloperPortfolio.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProjectService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<ProjectDTO>> GetProjectsAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7029/api/projects/dto");

            if (!response.IsSuccessStatusCode)
                return new();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ProjectDTO>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new();
        }
    }

}
