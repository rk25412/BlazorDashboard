namespace BlazorDashboard.Components.Pages;

public partial class HomePage
{
    private readonly List<BreadcrumbItem> _breadcrumb =
    [
        new("Home", Icon: "bi-house-door", Url: "/"),
        new("Dashboard")
    ];
}