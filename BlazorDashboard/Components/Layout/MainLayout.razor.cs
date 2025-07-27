namespace BlazorDashboard.Components.Layout;

public partial class MainLayout
{
    private bool _showSidebar = true;
    private Sidebar.Sidebar? _sidebar;

    protected override void OnInitialized()
    {
        _sidebar?.SetToggleSidebar(_showSidebar);
    }

    private void ToggleSidebar()
    {
        _showSidebar = !_showSidebar;
        _sidebar?.SetToggleSidebar(_showSidebar);
    }
}