using DeveloperPortfolio.Models.DTO;

namespace DeveloperPortfolio.Services
{
    public interface IProjectService
    {
        
      Task<List<ProjectDTO>> GetProjectsAsync();
        
    }
}
