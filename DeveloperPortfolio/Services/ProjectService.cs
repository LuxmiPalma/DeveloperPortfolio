using System.Text.Json;
using DeveloperPortfolio.Models.DTO;

namespace DeveloperPortfolio.Services
{
    public class ProjectService : IProjectService
    {
        private readonly HttpClient _httpClient;

        public ProjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<ProjectDTO>> GetProjectsAsync()
        {
            var response = await _httpClient.GetAsync("api/projects/dto");

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
