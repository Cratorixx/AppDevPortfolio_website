using System.ComponentModel.DataAnnotations;

namespace App_Dev.Models;

public enum ProjectCategory
{
    All,
    MobileApps,
    BackendConcurrency,
    UIUX
}

public record PortfolioMetric(string Value, string Label);

public record SimulationTaskItem(
    int Id,
    string Title,
    string Status,
    int ProgressPercent,
    string ColorTheme // emerald, amber, cyan, purple, teal
);

public record ProjectItem(
    string Id,
    string Title,
    string Subtitle,
    string Description,
    ProjectCategory Category,
    IReadOnlyList<string> Tags,
    string HighlightMetric,
    string ArchitectureFootnote,
    int Stars,
    int Commits,
    string WatermarkType, // radar, crosshair, none
    string? AccentColor = null,
    string? DemoUrl = null,
    string? SourceUrl = null,
    bool IsFeatured = false
);

public record SystemTopologyNode(
    string Id,
    string Name,
    string Subtitle,
    string TechStack,
    string Description,
    string Throughput,
    string Protocol,
    string FailureMode,
    string ThemeColor // purple, cyan, teal, emerald, amber
);

public record TechnicalHurdleItem(
    string Number,
    string Title,
    string Description
);

public record CaseStudyDetail(
    string ProjectId,
    string Title,
    string Subtitle,
    string Problem,
    string Solution,
    IReadOnlyList<string> DataStructures,
    IReadOnlyList<TechnicalHurdleItem> TechnicalHurdles,
    string CrashFreeRate,
    string StoreRating,
    IReadOnlyList<SystemTopologyNode> Nodes
);

public class ContactInquiryModel
{
    [Required(ErrorMessage = "Your name is required.")]
    [StringLength(60, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 60 characters.")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email address is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please select a project category.")]
    public string ProjectType { get; set; } = "Mobile Application";

    [Required(ErrorMessage = "Please provide an estimated timeline or budget.")]
    public string Timeline { get; set; } = "1-3 Months";

    [Required(ErrorMessage = "A brief description of your project is required.")]
    [StringLength(1000, MinimumLength = 10, ErrorMessage = "Message must be at least 10 characters.")]
    public string Message { get; set; } = string.Empty;
}
