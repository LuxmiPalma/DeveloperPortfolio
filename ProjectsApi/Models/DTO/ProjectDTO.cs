namespace ProjectsApi.Models.DTO
{
    public class ProjectDTO
    {
        public string ProjectImg { get; set; } = null!;
        public string Name { get; set; } = null!;
        public List<TechIconDTO> Technologies { get; set; } = new();
        public string TechStack { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Description { get; set; } = null!;
        public string GitHubUrl { get; set; } = null!;
        public string LiveDemoUrl { get; set; } = null!;
    }
}
