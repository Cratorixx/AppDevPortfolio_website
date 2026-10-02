# Peer Review — AppDevPortfolio_website by Froilan Cando
**Reviewer:** Ycany Ashra T. Sanchez    

---

## 1. Project Structure Rating: 8 / 10

Structure is straightforward. Components are split into Pages / Layout / Shared, with models in Models/PortfolioModels.cs and data behind Services/IPortfolioService.cs, so I could find things fast. I deducted some points because App Dev.csproj has a space in the name, generated CSS is checked into wwwroot/, and dotnet build fails until you run npm install first.

## 2. Front-End Rating: 9 / 10

UI looks good and clean, holds together across the four pages, layout collapses fine and the nav + hamburger work. Filters, star input, votes, and the contact modal all work as expected. I deducted some points because ScrollToForm doesn't actually scroll, and the Resume button just shows a toast with no file. Overall I like the design and the feel therefore I'll give it a 9.

## 3.  Suggestions

1. Make ScrollToForm scroll to the form, and either add a real resume file or change the button label.
2. Rename App Dev.csproj to AppDev.csproj and stop committing built CSS.
3. Add a screenshot to the README.

---