# AppDevPortfolio_website

A modern, high-performance developer portfolio website showcasing mobile applications, high-concurrency distributed system architectures, interactive terminal diagnostics, and peer reviews.

## Tech Stack

- **Framework**: ASP.NET Core Blazor (Interactive Server mode, .NET 8)
- **Language**: C# 12
- **Styling**: Tailwind CSS (v3.4.17) with `@tailwindcss/forms` and `@tailwindcss/container-queries`
- **CSS Pipeline**: Local Tailwind CLI build pipeline integrated into the MSBuild lifecycle

## Prerequisites

Before running the project locally, ensure you have the following installed:

- **[.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)** (or later)
- **[Node.js](https://nodejs.org/)** (v18+ recommended) and `npm`

## Getting Started

1. **Install Node dependencies:**
   ```bash
   npm install
   ```

2. **Build Tailwind CSS:**
   Compile the minified output stylesheet:
   ```bash
   npm run build:css
   ```
   *(Optional)* To watch for CSS/Razor changes during local development:
   ```bash
   npm run watch:css
   ```

3. **Run the Blazor application:**
   ```bash
   dotnet run
   ```
   Navigate to [http://localhost:5103](http://localhost:5103) (or `https://localhost:7186`) in your browser.

> **Note**: An MSBuild target (`BuildTailwind`) in `App Dev.csproj` automatically executes `npm run build:css` whenever you run `dotnet build` or `dotnet run`.

## Folder Overview

- **`Components/`**: Razor components and view logic
  - `Pages/`: Routable pages (`Home.razor`, `Projects.razor`, `SystemDesign.razor`, `Reviews.razor`, `Error.razor`)
  - `Layout/`: Application shell components (`MainLayout.razor`, `NavBar.razor`, `Footer.razor`)
  - `Shared/`: Interactive UI components (`ArchitectureDiagram.razor`, `ContactModal.razor`, `ProjectCard.razor`, `ProjectHeroCard.razor`, `TaskSimulationPreview.razor`, `TerminalWindow.razor`)
- **`Models/`**: Domain models and DTOs (`PortfolioModels.cs` for projects, metrics, system topology nodes, reviews, and contact forms)
- **`Services/`**: Data services and business logic (`IPortfolioService.cs` interface and `FakePortfolioService.cs` in-memory implementation)
- **`Styles/`**: Source stylesheets (`tailwind.input.css` containing custom theme utilities, glows, dot-grids, and gradient text classes)
- **`wwwroot/`**: Static assets including the compiled Tailwind bundle (`css/tailwind.output.css`) and favicon
