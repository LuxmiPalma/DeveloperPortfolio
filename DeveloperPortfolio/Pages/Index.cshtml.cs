using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DeveloperPortfolio.Models.DTO;
using DeveloperPortfolio.Services; 



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

        public async Task OnGetAsync()
        {
            Projects = await _projectService.GetProjectsAsync();
        }

    }
}
