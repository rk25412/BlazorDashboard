using Microsoft.AspNetCore.Components;

namespace BootstrapComponentLibrary;

public partial class Breadcrumb
{
    [Parameter] public IReadOnlyList<BreadcrumbItem> BreadcrumbItems { get; set; } = [];
    [Parameter] public string? Divider { get; set; }
    [Parameter] public BreadcrumbPosition Position { get; set; }

    private string _positionCssClass = string.Empty;
    protected override void OnInitialized()
    {
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