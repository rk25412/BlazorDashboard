namespace BlazorDashboard.Components;

public partial class App
{
    private bool _showSidebar = true;
    
    private void ToggleSidebar()
    {
        _showSidebar = !_showSidebar;
        InvokeAsync(StateHasChanged);
    }
}