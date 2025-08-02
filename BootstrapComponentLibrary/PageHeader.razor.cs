using Microsoft.AspNetCore.Components;

namespace BootstrapComponentLibrary;

public partial class PageHeader
{
    /// <summary>
    /// Page Header title
    /// </summary>
    [Parameter, EditorRequired] public string? Title { get; set; }
    
    /// <summary>
    /// List of breadcrumbs to show below the page title
    /// </summary>
    [Parameter] public List<BreadcrumbItem> Breadcrumbs { get; set; } = [];
    
    /// <summary>
    /// Divider for the breadcrumbs
    /// </summary>
    [Parameter] public string? BreadcrumbDivider { get; set; }
    
    /// <summary>
    /// Breadcrumb position
    /// </summary>
    [Parameter] public BreadcrumbPosition BreadcrumbPosition { get; set; } = BreadcrumbPosition.Left;
}