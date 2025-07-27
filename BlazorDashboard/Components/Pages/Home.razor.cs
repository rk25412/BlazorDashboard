using BlazorDashboard.Components.Shared;

namespace BlazorDashboard.Components.Pages;

public partial class Home
{
    private readonly List<BreadcrumbItem> _breadcrumb = [
        new("Home", "/"),
        new("Dashboard")
    ];
}