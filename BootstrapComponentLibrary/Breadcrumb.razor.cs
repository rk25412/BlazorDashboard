using Microsoft.AspNetCore.Components;

namespace BootstrapComponentLibrary;

public partial class Breadcrumb
{
    /// <summary>
    /// Breadcrumb list
    /// </summary>
    [Parameter] public List<BreadcrumbItem> BreadcrumbItems { get; set; } = [];
    
    /// <summary>
    /// Breadcrumb Divider
    /// </summary>
    [Parameter] public string? Divider { get; set; }
    
    /// <summary>
    /// Breadcrumb position
    /// </summary>
    [Parameter] public BreadcrumbPosition Position { get; set; }

    private string _positionCssClass = string.Empty;
    protected override void OnInitialized()
    {
        base.OnInitialized();
        Divider ??= "/";
        _positionCssClass = "d-flex justify-content-" + Position switch
        {
            BreadcrumbPosition.Center => "center",
            BreadcrumbPosition.Right => "end",
            _ => "start"
        };
    }
}

public record BreadcrumbItem(string Title, string? Icon = null, string? Url = null);

public enum BreadcrumbPosition
{
    Left,
    Center,
    Right
}