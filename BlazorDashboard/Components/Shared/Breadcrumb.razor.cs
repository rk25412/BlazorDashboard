using Microsoft.AspNetCore.Components;

namespace BlazorDashboard.Components.Shared;

public partial class Breadcrumb : ComponentBase
{
    [Parameter] public IReadOnlyList<BreadcrumbItem> BreadcrumbItems { get; set; } = [];
}

public record BreadcrumbItem(string Title, string? Url = null);