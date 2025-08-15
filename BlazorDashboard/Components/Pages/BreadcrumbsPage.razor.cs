using BootstrapComponentLibrary;
using Microsoft.AspNetCore.Components;

namespace BlazorDashboard.Components.Pages;

public partial class BreadcrumbsPage : ComponentBase
{
    private readonly List<BreadcrumbItem> _breadcrumb =
    [
        new("Home", Icon: "bi-house-door", Url: "/"),
        new("Components"),
        new("Breadcrumbs"),
    ];
}