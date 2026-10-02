# Peer Review — AppDevPortfolio_website
**Reviewer:** OpenCode (automated peer review)
**Date:** 2026-10-02
**Commit reviewed:** `2ccbd12` — "chore(project): clean repository, update gitignore, and add readme"
**Scope:** Repository/project organization and front-end interface (static code review + build attempt; no live browser run — see notes).

---

## 1. Project Structure Rating: 8 / 10

The repository is cleanly organized around standard Blazor conventions, which makes it easy to navigate on a first read. Splitting `Components/` into `Pages/` (routable views: `Home`, `Projects`, `SystemDesign`, `Reviews`, `Error`), `Layout/` (`MainLayout`, `NavBar`, `Footer`), and `Shared/` (reusable cards, diagrams, terminal, modal) is a sensible separation, and pairing `Models/PortfolioModels.cs` (records + validated form models) with `Services/IPortfolioService.cs` + `FakePortfolioService.cs` registered via DI in `Program.cs` shows good layering between UI, domain, and data. File and folder naming is consistent (PascalCase components, descriptive names like `TaskSimulationPreview.razor`), the `README.md` documents the stack, prerequisites, setup steps, and folder overview accurately, and the `.gitignore` correctly covers `bin/`, `obj/`, `.vs/`, and `node_modules/`. Commit history follows a readable conventional style (`feat(home): …`, `fix(home): …`, `style(portfolio): …`, `chore(…): …`) with scoped messages rather than one squashed dump.

Deductions are minor but real. The project file is named `App Dev.csproj` (with a space), which forces the `AssemblyName.Replace(' ', '_')` workaround and makes `dotnet` CLI usage awkward — renaming to `AppDev.csproj` would remove a papercut. Generated artifacts are committed (`wwwroot/css/tailwind.output.css`, `wwwroot/bootstrap/*`, legacy `wwwroot/app.css` alongside the Tailwind pipeline), which bloats diffs and risks divergence from `Styles/tailwind.input.css`; ideally only the input CSS + config are tracked. There are no tests, no solution (`.sln`) file, and the MSBuild `BuildTailwind` target unconditionally runs `npm run build:css`, so a fresh clone fails to build until `npm install` is run first (verified: `dotnet build` errors with `'tailwindcss' is not recognized`) — guarding the target or documenting the ordering more prominently would help contributors.

## 2. Front-End Rating: 7.5 / 10

The interface is visually polished and clearly the strongest part of the project. The dark obsidian theme is consistent across all four routes (shared `max-w-7xl` container, mono pill badges like `02 • SELECTED WORK`, purple-to-indigo gradient CTAs, glowing shadows, `selection:bg-purple-600`), and the sticky blurred `NavBar` with gradient active-link underlines, "Available for roles" status badge, and working mobile hamburger menu gives the site a professional shell. Layout work is responsive (single column collapsing to `lg:grid-cols-12` grids on Home and SystemDesign, `md:grid-cols-2` card feeds, `overflow-x-auto` filter bars), typography hierarchy is clear (extrabold tracking-tight headlines, mono metadata, readable body copy), and the app is genuinely interactive rather than static: category filters with empty-state + reset, an interactive star-rating selector with hover labels, a rating-breakdown dashboard, helpful-vote counters, success banners, a contact modal with validation, and a resume-request toast.

Deductions come from completeness and dead ends rather than visuals. Two nav anchors are dead: `STACK` points to `work#stack` and `ABOUT` to `#about`, but neither target `id` exists anywhere in `Components/` (only `write-review-form` was found), so those clicks go nowhere, and the "Write a Review" button's `ScrollToForm` handler only dismisses the banner instead of scrolling to the form despite its name. The Resume button shows a toast ("Resume Download Initiated") without delivering a file, and inquiries/reviews persist only in memory via `FakePortfolioService`, which is fine for a demo but means the headline CTAs don't complete real user goals. Minor readability notes: frequent 10–11px mono microcopy is stylish but strains at small sizes, and the `README` has no screenshots or live-demo link, so evaluators can't preview the UI without running the .NET + Node toolchain.

---

## 3. Verification notes (what was checked)

- Read `README.md`, `Program.cs`, `App Dev.csproj`, `package.json`, `tailwind.config.js`, `.gitignore`, all files under `Components/`, `Models/PortfolioModels.cs`, `Services/`.
- `git log --oneline` (7 conventional commits) and `git status` reviewed.
- Ran `dotnet build`: fails on clean checkout because `node_modules/` is absent and the `BuildTailwind` target shells out to `npm run build:css` — confirming the documented `npm install` prerequisite is load-bearing.
- Grepped `Components/` for `id="about"`, `id="stack"`, `id="write-review-form"`: only the review form anchor exists, confirming the dead `STACK`/`ABOUT` links.
- No live browser run was performed (build toolchain incomplete in this environment); UI judgments are from Razor/Tailwind source inspection.

## 4. Top suggested fixes (highest value first)

1. Fix or remove dead anchors (`work#stack`, `#about`) — add the sections or drop the links.
2. Make `ScrollToForm` actually scroll (JS interop `scrollIntoView`) and either ship a real resume asset or label the button honestly.
3. Rename `App Dev.csproj` → `AppDev.csproj` and stop tracking generated CSS (`tailwind.output.css`, `bootstrap/*`) or add them to `.gitignore`.
4. Guard the `BuildTailwind` target (e.g., `Condition="Exists('node_modules')"`) with a clear warning so `dotnet build` degrades gracefully.
5. Add screenshots/GIFs and a demo link to the `README`, plus a couple of bUnit/smoke tests for the review filtering logic.

---

*Submitted per assignment instructions as a review file + pull request (see branch `peer-review`).*
