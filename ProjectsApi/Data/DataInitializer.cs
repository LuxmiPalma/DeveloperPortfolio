using ProjectsApi.Models;

namespace ProjectsApi.Data
{
    public class DataInitializer
    {
        public static void SeedDatabase(AppDbContext context)
        {
            //if (!context.Projects.Any())
            //{
                var baseUrl = "https://localhost:7083";

                // Create icons first
                var dotnet = new TechIcon { Technology = "ASP.NET Core", Url = $"{baseUrl}/icons/Asp-net.png" };
                var razor = new TechIcon { Technology = "Razor Pages", Url = $"{baseUrl}/icons/razor-icon.png" };
                var sql = new TechIcon { Technology = "SQL Server", Url = $"{baseUrl}/icons/Sql.png" };
                var ef = new TechIcon { Technology = "Entity Framework", Url = $"{baseUrl}/icons/icons8-.net-framework-48.png" };
                var api = new TechIcon { Technology = "Web API", Url = $"{baseUrl}/icons/web-api-icon.png" };
                var java = new TechIcon { Technology = "Java", Url = $"{baseUrl}/icons/Java.png" };
                var react = new TechIcon { Technology = "React", Url = $"{baseUrl}/icons/React.png" };
                var vite = new TechIcon { Technology = "Vite", Url = $"{baseUrl}/icons/Vite.png" };
                var html = new TechIcon { Technology = "HTML", Url = $"{baseUrl}/icons/Html.png" };
                var csharp = new TechIcon { Technology = "C#", Url = $"{baseUrl}/icons/C-sharp.png" };

            context.TechIcons.AddRange(dotnet, razor, sql, ef, api, java, react, vite, html);
                context.SaveChanges();

                var bankProject = new Project
                {
                    ProjectImg = $"{baseUrl}/images/img-Bank.png",                    
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
                        new TechStack { TechIcon = sql },
                        new TechStack { TechIcon = ef },
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
                var siliconProject = new Project
                {
                    ProjectImg = $"{baseUrl}/images/Silicon.png",
                    Name = "Silicon",
                    TechStack = "Java, React, Vite, HTML",
                    Date = new DateTime(2025, 2, 15),
                    Description = "A responsive front-end project built using HTML, CSS, React, Vite, and JavaScript. ",
                    GitHubUrl = "https://github.com/LuxmiPalma/Silicon-Vite.git",
                    LiveDemoUrl = "https://example-silicon.com", 
                    Technologies = new List<TechStack>

                    {
                       new TechStack { TechIcon = java },
                        new TechStack { TechIcon = react },
                        new TechStack { TechIcon = vite },
                        new TechStack { TechIcon = html }
                    }
    
                };
                var CashRegisterProject = new Project
                {
                    ProjectImg = $"{baseUrl}/images/cashReg.png",
                    Name = "Cash Register",
                    TechStack = "c#, SQL Server",
                    Date = new DateTime(2025, 5, 20),
                    Description = "Personal developer portfolio with projects fetched via API.",
                    GitHubUrl = "https://github.com/LuxmiPalma/Lux-Cash-Register-New.git",
                    LiveDemoUrl = "",

                    Technologies = new List<TechStack>
                    {
                        new TechStack { TechIcon = dotnet },
                        new TechStack { TechIcon = sql },
                        new TechStack { TechIcon = csharp }



                    }
           
                };

                var bookingConsoleProject = new Project
                {
                    ProjectImg = $"{baseUrl}/images/Hotel.png",
                    Name = "Booking System",
                    TechStack = "ASP.NET Core, JavaScript, SQL Server",
                    Date = new DateTime(2024, 11, 10),
                    Description = "A web app for booking rooms and managing schedules.",
                    GitHubUrl = "https://github.com/LuxmiPalma/Sun-Flower-Hotel.git",
                    LiveDemoUrl = "",

                    Technologies = new List<TechStack>
                    {
                        new TechStack { TechIcon = dotnet },
                        new TechStack { TechIcon = sql },
                        new TechStack { TechIcon = csharp },

                     }
                };

                var ticTacToeProject = new Project
                {
                    ProjectImg = $"{baseUrl}/images/game.png",
                    Name = "Console Game",
                    TechStack = "C#, Console App",
                    Date = new DateTime(2024, 9, 5),
                    Description = "A console-based math game with score tracking and levels.",
                    GitHubUrl = "https://github.com/LuxmiPalma/Tic-tac-toe.git",
                    LiveDemoUrl = "",
                    Technologies = new List<TechStack>
                    {
                        new TechStack { TechIcon = dotnet },
                        new TechStack { TechIcon = csharp },
                        

                    }
                };


                var mathUtilityProject = new Project
                {
                    ProjectImg = $"{baseUrl}/images/infinitapp.png",
                    Name = "Mathutility App",
                    TechStack = "ASP.NET Core, Entity Framework, SQL Server",
                    Date = new DateTime(2024, 12, 2),
                    Description = "A project demonstrating use of design patterns and data persistence.",
                    GitHubUrl = "https://github.com/LuxmiPalma/InfinityApp.git",
                    LiveDemoUrl = "",
                    Technologies = new List<TechStack>
                    { 
                    new TechStack { TechIcon = dotnet },
                    new TechStack { TechIcon = sql },
                    new TechStack { TechIcon = csharp },
},
                    
                
            

                };


                context.Projects.AddRange(bankProject, adsProject, siliconProject,CashRegisterProject, bookingConsoleProject,ticTacToeProject,mathUtilityProject);
                context.SaveChanges();
            }
        
    }
}

