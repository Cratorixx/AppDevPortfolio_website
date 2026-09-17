using App_Dev.Models;

namespace App_Dev.Services;

public interface IPortfolioService
{
    Task<IReadOnlyList<PortfolioMetric>> GetHeroMetricsAsync();
    Task<IReadOnlyList<string>> GetCodeSnippetLinesAsync();
    Task<IReadOnlyList<SystemTopologyNode>> GetTopologyNodesAsync();
    Task<SystemTopologyNode?> GetTopologyNodeByIdAsync(string id);
    Task<IReadOnlyList<ProjectItem>> GetProjectsAsync(ProjectCategory category = ProjectCategory.All);
    Task<ProjectItem?> GetFeaturedProjectAsync();
    Task<IReadOnlyList<SimulationTaskItem>> GetSimulationTasksAsync();
    Task<SimulationTaskItem> RefreshSimulationTaskAsync(int taskId);
    Task<CaseStudyDetail> GetCaseStudyAsync(string id = "flowtrack");
    Task<bool> SubmitInquiryAsync(ContactInquiryModel inquiry);
}
