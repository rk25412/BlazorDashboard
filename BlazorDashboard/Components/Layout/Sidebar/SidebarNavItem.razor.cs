using Microsoft.AspNetCore.Components;

namespace BlazorDashboard.Components.Layout.Sidebar;

public partial class SidebarNavItem : ComponentBase
{
    [Parameter, EditorRequired] public SidebarNavModel? NavItem { get; set; }
    private string Id { get; } = Guid.NewGuid().ToString();
}

public class SidebarNavModel
{
    public string? Icon { get; set; }
    public string? Title { get; set; }
    public string? Href { get; set; }
    public List<SidebarNavModel> SubItems { get; set; } = [];
}