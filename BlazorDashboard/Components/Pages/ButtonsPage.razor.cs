namespace BlazorDashboard.Components.Pages;

public partial class ButtonsPage : ComponentBase
{
    private readonly List<BreadcrumbItem> _breadcrumb =
    [
        new("Home", Icon: "bi-house-door", Url: "/"),
        new("Components"),
        new("Breadcrumbs"),
    ];
}