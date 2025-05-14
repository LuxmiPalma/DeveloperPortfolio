namespace ProjectsApi.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TechStack { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string GitHubUrl { get; set; }
        public string LiveDemoUrl { get; set; }
    }
}
