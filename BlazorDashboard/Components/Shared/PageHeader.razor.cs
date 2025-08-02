using Microsoft.AspNetCore.Components;

namespace BlazorDashboard.Components.Shared;

public partial class PageHeader
{
    [Parameter, EditorRequired] public string? Title { get; set; }
    [Parameter] public List<BreadcrumbItem> Breadcrumbs { get; set; } = [];
    [Parameter] public string? BreadcrumbDivider { get; set; }
    [Parameter] public BreadcrumbPosition BreadcrumbPosition { get; set; } = BreadcrumbPosition.Left;
}