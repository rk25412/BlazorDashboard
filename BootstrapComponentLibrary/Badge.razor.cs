using System.Diagnostics;
using Microsoft.AspNetCore.Components;

namespace BootstrapComponentLibrary;

public partial class Badge
{
    /// <summary>
    /// Badge Color
    /// </summary>
    [Parameter] public BadgeColor BadgeColor { get; set; } = BadgeColor.Primary;
    
    /// <summary>
    /// Badge Style
    /// </summary>
    [Parameter] public BadgeVariant BadgeStyle { get; set; } = BadgeVariant.Flat;
    
    /// <summary>
    /// Text Color
    /// </summary>
    [Parameter] public TextColor TextColor { get; set; } = TextColor.Primary;
    
    /// <summary>
    /// Indicates whether, the badge should have rounded edges
    /// </summary>
    [Parameter] public bool Pill { get; set; }
    
    /// <summary>
    /// Text to show in the badge
    /// </summary>
    [Parameter] public string Text { get; set; } = string.Empty;
    
    /// <summary>
    /// Child Content for custom html
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    private string GetCssClasses()
    {
        var badgeColorClasses = "badge " + (Pill ? "rounded-pill " : "") + (BadgeStyle is BadgeVariant.Flat
            ? "bg-"
            : "border border-1 border-") + BadgeColor switch
        {
            BadgeColor.Primary => "primary",
            BadgeColor.Secondary => "secondary",
            BadgeColor.Success => "success",
            BadgeColor.Danger => "danger",
            BadgeColor.Warning => "warning",
            BadgeColor.Info => "info",
            BadgeColor.Light => "light",
            BadgeColor.Dark => "dark",
            BadgeColor.White => "white",
            _ => "primary"
        } + " text-" + TextColor switch
        {
            TextColor.Primary => "primary",
            TextColor.Secondary => "secondary",
            TextColor.Success => "success",
            TextColor.Danger => "danger",
            TextColor.Warning => "warning",
            TextColor.Info => "info",
            TextColor.Light => "light",
            TextColor.Dark => "dark",
            TextColor.White => "white",
            TextColor.Black => "black",
            _ => "primary"
        };

        return badgeColorClasses;
    }
}

public enum BadgeColor
{
    Primary,
    Secondary,
    Success,
    Danger,
    Warning,
    Info,
    Light,
    Dark,
    White
}

public enum TextColor
{
    Primary,
    Secondary,
    Success,
    Danger,
    Warning,
    Info,
    Light,
    Dark,
    White,
    Black,
}

public enum BadgeVariant
{
    Flat,
    Outlined
}