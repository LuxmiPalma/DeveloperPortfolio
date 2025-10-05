using Microsoft.EntityFrameworkCore;
using ProjectsApi.Data;


var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}
else
{
    var home = Environment.GetEnvironmentVariable("HOME") ?? @"D:\home";
    var dataDir = Path.Combine(home, "site", "wwwroot", "app_data");
    Directory.CreateDirectory(dataDir);
    var sqlitePath = Path.Combine(dataDir, "projects.db");

    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite($"Data Source={sqlitePath}"));
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

    ctx.Database.EnsureCreated(); 
    if (!ctx.Projects.Any()) DataInitializer.SeedDatabase(ctx, env);
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
