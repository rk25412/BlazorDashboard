using Microsoft.AspNetCore.Components;

namespace BlazorDashboard.Components.Shared;

public partial class PageHeader : ComponentBase
{
    [Parameter, EditorRequired] public string? Title { get; set; }

    [Parameter] public List<BreadcrumbItem> Breadcrumbs { get; set; } = [];
}