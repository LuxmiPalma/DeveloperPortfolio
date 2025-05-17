namespace ProjectsApi.Models
{
    public class TechStack
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;

        public int TechIconId { get; set; }
        public TechIcon TechIcon { get; set; } = null!;
    }

    
}
