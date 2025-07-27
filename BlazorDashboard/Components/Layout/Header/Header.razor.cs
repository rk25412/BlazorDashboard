using Microsoft.AspNetCore.Components;

namespace BlazorDashboard.Components.Layout.Header;

public partial class Header : ComponentBase
{
    [Parameter]
    public EventCallback SidebarToggled { get; set; }

    private void ToggleSidebar()
    {
        SidebarToggled.InvokeAsync();
    }
}