
# 👨‍💻 Luxmi Palma - Developer Portfolio

This is my professional developer portfolio built with **ASP.NET Core Razor Pages** and powered by a **.NET Web API** that dynamically serves all my project data, including images, technologies, and live links.

## 🔗 Live Site

- 🌐 [luxmiportfolio](https://luxmiportfolio-cee0e6eadjf6dda8.swedencentral-01.azurewebsites.net)

---

## 🧰 Tech Stack

- **Frontend**: Razor Pages (.NET 8),Custom Bootstrap-based styling, PureCounter.js, AOS animations
- **Database**: SQL Server (EF Core Code-First)
- **Hosting**: Azure App Services
- **Deployment**: Visual Studio Publish
- **Email Contact**: SMTP (Gmail App Password)

---

## 📁 Project Structure

```
Solution
│
├── DeveloperPortfolio/           # Razor Pages frontend
│   └── wwwroot/
│       ├── icons/                # Tech stack icons
│       └── images/               # Project screenshots
│
├── ProjectsApi/                  # Web API backend
│   └── DataInitializer.cs        # Seeds the project & tech data
```

---

## 🌟 Features

- 💡 **Dynamic Portfolio**: Projects and tech stacks are fetched from the Web API in real-time
- 🌐 **Live URLs**: GitHub + optional Live Demo links per project
- 📊 **Animated Stats**: Country-based stats using PureCounter
- ✉️ **Contact Form**: Sends real emails using Gmail SMTP
- 🧠 **DTOs**: Clean separation of database models and API responses

---

## 🗃️ API Endpoints

- `GET /api/projects/dto` → returns full list of projects with image URLs and tech stack icons
- `GET /api/projects/{id}` → return details of a single project
- `POST /api/projects` → add a new project (for admin/dev use)

---

## 🛠 Deployment Notes

- The Razor Pages site and Web API are **hosted separately** on Azure.
- Image and icon URLs are served from the **Razor Pages project's `wwwroot/`**, not from the API.
- All image paths in the database are generated using:

```csharp
var baseUrl = env.IsDevelopment()
    ? "https://localhost:7083"
    : "https://luxmiportfolio-cee0e6eadjf6dda8.swedencentral-01.azurewebsites.net";
```

- Database is seeded via `DataInitializer.SeedDatabase()`.

---

## 📬 Contact

If you’d like to reach out, feel free to submit a message through the [contact form](https://luxmiportfolio-cee0e6eadjf6dda8.swedencentral-01.azurewebsites.net/#contact).

---

## 📌 Author

**Luxmi Palma**  
.NET Developer | Full-Stack Enthusiast  
🇸🇪 Based in Sweden

---



## 📝 License

This project is for educational and personal branding purposes. All content © Luxmi Palma.
