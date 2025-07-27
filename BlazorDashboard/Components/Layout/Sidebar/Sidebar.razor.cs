using Microsoft.AspNetCore.Components;

namespace BlazorDashboard.Components.Layout.Sidebar;

public partial class Sidebar : ComponentBase
{
    private bool _showSidebar = true;

    public void ToggleSidebar()
    {
        _showSidebar = !_showSidebar;
        InvokeAsync(StateHasChanged);
    }
}