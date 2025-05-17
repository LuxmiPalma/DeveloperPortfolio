using ProjectsApi.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace ProjectsApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<TechStack> TechStacks { get; set; }
        public DbSet<TechIcon> TechIcons { get; set; }
    }
}
