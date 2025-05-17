using ProjectsApi.Models;

namespace ProjectsApi.Data
{
    public class DataInitializer
    {
        public static void SeedDatabase(AppDbContext context)
        {
            if (!context.Projects.Any())
            {

                // Create icons first
                var dotnet = new TechIcon { Technology = "ASP.NET Core", Url = "/icons/dotnet.png" };
                var razor = new TechIcon { Technology = "Razor Pages", Url = "/icons/razor.png" };
                var sql = new TechIcon { Technology = "SQL Server", Url = "/icons/sql.png" };
                var ef = new TechIcon { Technology = "Entity Framework", Url = "/icons/ef.png" };
                var api = new TechIcon { Technology = "Web API", Url = "/icons/api.png" };

                var bankProject = new Project
                {
                    ProjectImg = "/img/bankapp.jpg",
                    Name = "BankApp",
                    TechStack = "ASP.NET Core, Razor Pages, SQL Server",
                    Date = new DateTime(2025, 1, 15),
                    Description = "A simple banking system with account management and transactions.",
                    GitHubUrl = "https://github.com/LuxmiPalma/BankAB.git",
                    LiveDemoUrl = "https://nextgenbank-h2a2hxhqa4a2gbgx.swedencentral-01.azurewebsites.net",
                    Technologies = new List<TechStack>
                    {
                        new TechStack { TechIcon = dotnet },
                        new TechStack { TechIcon = razor },
                        new TechStack { TechIcon = sql }
                    }
                };

                var adsProject = new Project
                {
                    ProjectImg = "/img/adapi.jpg",
                    Name = "Ad API",
                    TechStack = "ASP.NET Core Web API, Entity Framework, SQL Server",
                    Date = new DateTime(2025, 3, 1),
                    Description = "An ad listing API similar to Blocket.se for managing ads.",
                    GitHubUrl = "https://github.com/LuxmiPalma/BlocketAdsApi.git",
                    LiveDemoUrl = "https://example.com",

                    Technologies = new List<TechStack>
                    {
                        new TechStack { TechIcon = dotnet },
                        new TechStack { TechIcon = ef },
                        new TechStack { TechIcon = sql },
                        new TechStack { TechIcon = api }
                    }
                };

                context.Projects.AddRange(bankProject, adsProject);
                context.SaveChanges();
            }
        }
    }
}

