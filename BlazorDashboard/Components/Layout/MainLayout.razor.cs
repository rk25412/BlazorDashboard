namespace BlazorDashboard.Components.Layout;

public partial class MainLayout
{
    private bool _showSidebar = true;
    private Sidebar.Sidebar? _sidebar;

    
    private void ToggleSidebar()
    {
        _showSidebar = !_showSidebar;
        _sidebar?.SetToggleSidebar(_showSidebar);
    }
}