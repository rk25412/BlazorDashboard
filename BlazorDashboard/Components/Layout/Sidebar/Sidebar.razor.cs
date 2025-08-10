using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorDashboard.Components.Layout.Sidebar;

public partial class Sidebar : ComponentBase
{
    private bool _showSidebar = true;
    private List<SidebarNavModel> _sidebarNavItems = [];

    protected override void OnInitialized()
    {
        _sidebarNavItems =
        [
            new SidebarNavModel
            {
                Title="Dashboard", Href = "/", Icon = "bi bi-grid"
            },
            new SidebarNavModel
            {
                Title="Components", Icon = "bi bi-menu-button-wide",
                SubItems = 
                [
                    new SidebarNavModel { Title = "Alerts", Href = "/alerts" }
                ]
            },
            new SidebarNavModel
            {
                Title="Forms", Icon = "bi bi-journal-text",
                SubItems = 
                [
                    new SidebarNavModel { Title = "Form Elements", Href = "/form-elements" }
                ]
            },
            
        ];
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JsRuntime.InvokeVoidAsync("setActiveMenu");
        }
    }

    public void SetToggleSidebar(bool show)
    {
        _showSidebar = show;
        InvokeAsync(StateHasChanged);
    }
    
    
}