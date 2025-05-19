using ProjectsApi.Models;

namespace ProjectsApi.Data
{
    public class DataInitializer
    {
        public static void SeedDatabase(AppDbContext context)
        {
            if (!context.Projects.Any())
            {
                var baseUrl = "https://localhost:7083";

                // Create icons first
                var dotnet = new TechIcon { Technology = "ASP.NET Core", Url = $"{baseUrl}/icons/ASP-core.jpg" };
                var razor = new TechIcon { Technology = "Razor Pages", Url = $"{baseUrl}/icons/razor-icon.png" };
                var sql = new TechIcon { Technology = "SQL Server", Url = $"{baseUrl}/icons/sql-server-icon.png" };
                var ef = new TechIcon { Technology = "Entity Framework", Url = $"{baseUrl}/icons/icons8-.net-framework-48.png" };
                var api = new TechIcon { Technology = "Web API", Url = $"{baseUrl}/icons/web-api-icon.png" };

                var bankProject = new Project
                {
                    ProjectImg = $"{baseUrl}/images/img-Bank.png",                    Name = "BankApp",
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
                    ProjectImg = $"{baseUrl}/images/img-api.png",
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

