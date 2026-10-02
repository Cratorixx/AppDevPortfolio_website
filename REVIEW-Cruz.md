# Peer Project Review

**Reviewer:** Gianne Cruz  
**Project Reviewed:** AppDevPortfolio_website (Software Engineer Portfolio)  
**Repository:** https://github.com/Gianne818/AppDevPortfolio_website.git  
**Date:** October 2, 2026  

---

### 1. Project Structure Rating: 9/10

**Feedback & Justification:**  
The repository exhibits excellent structural discipline and adheres to modern ASP.NET Core Blazor architecture. Razor components are thoughtfully organized into logical subdirectories (`Components/Pages`, `Components/Layout`, and `Components/Shared`), separating route-level views from reusable interface primitives. Code architecture is clean, decoupling data access behind the `IPortfolioService` interface and its in-memory `FakePortfolioService` implementation, which is cleanly registered via dependency injection in `Program.cs`. The repository cleanliness is top-tier: a well-crafted `.gitignore` prevents compiled binaries (`bin/`, `obj/`) and `node_modules/` from polluting source control, complemented by a detailed `README.md` documenting prerequisites, folder breakdowns, and build steps. The commit history follows clear conventional commit standards (`chore:`, `feat:`, `fix:`, `style:`). The only structural drawbacks are that the C# project file name `App Dev.csproj` contains whitespace (requiring an explicit `<AssemblyName>` string replacement workaround in MSBuild), and the custom `BeforeTargets="Build"` target unconditionally invokes `npm run build:css` without checking for installed `node_modules`, causing initial `dotnet build` executions to fail immediately if dependencies were not manually restored first.

---

### 2. Front-End Rating: 8.5/10

**Feedback & Justification:**  
The front-end design is visually striking, featuring a cohesive dark-mode theme, luminous gradients, refined typography, and subtle glow accents that give it a polished, high-tech engineering aesthetic. Interactive capabilities are well above average, notably the interactive `TerminalWindow` with its multi-tab code viewer and system topology preview, the SVG-rendered `ArchitectureDiagram` with clickable node inspection drawers, and a fully functional peer review form with live star rating hovers, form validation, and reactive in-memory submission handling. Responsiveness is properly accounted for with a working hamburger menu drawer on mobile breakpoints. However, paying close attention to finer details reveals a few unfinished areas and dead ends: the main navigation bar contains dead anchor links (`STACK` pointing to `work#stack` and `ABOUT` pointing to `#about`), neither of which match any element ID in the rendered DOM. Furthermore, clicking the "Resume" button in the header triggers a simulated download toast with mismatched template copy (`"Generating verified PDF transcript for AK..."`) referencing the initials "AK" instead of the portfolio owner's "JF" monogram, and without delivering an actual document.

---

### Key Strengths & Suggestions for Improvement

- **Strengths:** 
  - Sophisticated dark-mode design system using Tailwind CSS with custom glow utilities and responsive card layouts.
  - Highly dynamic interactive elements including the multi-tab terminal, interactive architecture topology nodes, and live review rating submission.
  - Clean separation of concerns with dedicated models, service contracts, and modular layout components.
  - Comprehensive `README.md` and a clean repository free of build output clutter.

- **Suggestions:**
  - Rename `App Dev.csproj` to `AppDev.csproj` (removing the space) to align with .NET naming conventions and prevent CLI/tooling escaping issues.
  - Fix dead navigation anchors by either implementing matching container `id` attributes (`id="stack"`, `id="about"`) or routing those links to dedicated pages.
  - Clean up the placeholder copy in the resume download toast (`MainLayout.razor:L23`) to match the author's initials and link a real PDF download asset.
  - Add a safety check or pre-install step to the MSBuild `BuildTailwind` target (e.g., checking if Tailwind is executable) so new clones do not fail `dotnet build` before `npm install` is run.
