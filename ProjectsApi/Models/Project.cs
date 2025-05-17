namespace ProjectsApi.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectImg { get; set; } = null!;

        public string Name { get; set; }
        public List<TechStack> Technologies { get; set; } = new();

        public string TechStack { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string GitHubUrl { get; set; }
        public string LiveDemoUrl { get; set; }
    }
}
