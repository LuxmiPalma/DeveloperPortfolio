using DeveloperPortfolio.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DeveloperPortfolio.Models.DTO;
using DeveloperPortfolio.Services;

namespace DeveloperPortfolio.Pages
{
    public class PortfolioModel : PageModel
    {
        private readonly IProjectService _projectService;

        public PortfolioModel(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public List<ProjectDTO> Projects { get; set; } = new();

        public async Task OnGetAsync()
        {
            Projects = await _projectService.GetProjectsAsync();
        }
    }
}
