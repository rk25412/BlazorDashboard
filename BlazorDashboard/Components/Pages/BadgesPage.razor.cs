namespace BlazorDashboard.Components.Pages;

public partial class BadgesPage : ComponentBase
{
    private readonly List<BreadcrumbItem> _breadcrumb =
    [
        new("Home", Icon: "bi-house-door", Url: "/"),
        new("Components"),
        new("Badges"),
    ];
}