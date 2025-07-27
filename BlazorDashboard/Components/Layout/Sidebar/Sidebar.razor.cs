using Microsoft.AspNetCore.Components;

namespace BlazorDashboard.Components.Layout.Sidebar;

public partial class Sidebar : ComponentBase
{
    private bool _showSidebar = true;

    public void SetToggleSidebar(bool show)
    {
        _showSidebar = show;
        InvokeAsync(StateHasChanged);
    }
}