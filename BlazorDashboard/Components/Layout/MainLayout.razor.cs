namespace BlazorDashboard.Components.Layout;

public partial class MainLayout
{
    private Sidebar.Sidebar? _sidebar;

    public void ToggleSidebar()
    {
        _sidebar?.ToggleSidebar();
    }
}