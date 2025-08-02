using Microsoft.AspNetCore.Components;

namespace BootstrapComponentLibrary;

public partial class Alert
{
    /// <summary>
    /// Message to show in the Alert
    /// </summary>
    [Parameter] public string? Message { get; set; }
    
    /// <summary>
    /// Indicates whether the alert is closable
    /// </summary>
    [Parameter] public bool Closable { get; set; } = true;
    
    /// <summary>
    /// Event Callback for Closing the alert
    /// </summary>
    [Parameter] public EventCallback OnClose { get; set; }
    
    /// <summary>
    /// Alert Color
    /// </summary>
    [Parameter] public AlertColor AlertColor { get; set; } = AlertColor.Primary;
    
    /// <summary>
    /// Alert Style
    /// </summary>
    [Parameter] public AlertStyle AlertStyle { get; set; } = AlertStyle.Default;
    
    /// <summary>
    /// Icon to show in the alert
    /// </summary>
    [Parameter] public string? Icon { get; set; }
    
    /// <summary>
    /// Custom template for the alert
    /// </summary>
    [Parameter] public RenderFragment? Template { get; set; }

    private string GetCssClass()
    {
        var colorClass = AlertColor switch
        {
            AlertColor.Secondary => "secondary",
            AlertColor.Info => "info",
            AlertColor.Success => "success",
            AlertColor.Danger => "danger",
            AlertColor.Warning => "warning",
            AlertColor.Light => "light",
            AlertColor.Dark => "dark",
            _ => "primary"
        };

        var styleClass = AlertStyle switch
        {
            AlertStyle.Solid => "text-light border-0 bg-" + colorClass,
            AlertStyle.Outlined => $"border-{colorClass}",
            _ => ""
        };

        var @class =
            $"alert alert-dismissible {(AlertStyle is AlertStyle.Default ? $"alert-{colorClass}" : "")} {styleClass} fade show";
        return @class;
    }
}

public enum AlertColor
{
    Primary,
    Secondary,
    Success,
    Danger,
    Warning,
    Info,
    Light,
    Dark
}

public enum AlertStyle
{
    Default,
    Solid,
    Outlined,
}