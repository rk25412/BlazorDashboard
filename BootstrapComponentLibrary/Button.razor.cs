using Microsoft.AspNetCore.Components;

namespace BootstrapComponentLibrary;

public partial class Button
{
    [Parameter] public string? Text { get; set; }
    [Parameter] public ButtonType ButtonType { get; set; } = ButtonType.Default;
    [Parameter] public ButtonVariant ButtonVariant { get; set; } = ButtonVariant.Flat;
    [Parameter] public ButtonColor ButtonColor { get; set; } = ButtonColor.Primary;
    [Parameter] public ButtonSize ButtonSize { get; set; } = ButtonSize.Default;
    [Parameter] public TextColor? TextColor { get; set; }
    [Parameter] public bool Disabled { get; set; }
    [Parameter] public RenderFragment? ChildContent { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (ButtonType is not ButtonType.Default)
        {
            Attributes.Add("type", ButtonType is ButtonType.Button ? "button" : "submit");
        }
    }

    private new void OnClick()
    {
        if (!Disabled)
        {
            base.OnClick.InvokeAsync();
        }
    }

    private string GetButtonCssClasses()
    {
        return $"btn-{
            (ButtonVariant is ButtonVariant.Outlined ? "outline-" : "")
        }{
            ButtonColor switch {
                ButtonColor.Primary => "primary",
                ButtonColor.Secondary => "secondary",
                ButtonColor.Success => "success",
                ButtonColor.Danger => "danger",
                ButtonColor.Warning => "warning",
                ButtonColor.Info => "info",
                ButtonColor.Light => "light",
                ButtonColor.Dark => "dark",
                ButtonColor.Link => "link",
                _ => "primary"
            }
        } {
            ButtonSize switch {
                ButtonSize.Small => "btn-sm",
                ButtonSize.Large => "btn-lg",
                _ => ""
            }
        }";
    }

    private string GetTextCssClasses()
    {
        return TextColor is null
            ? ""
            : "text-" + TextColor switch
            {
                BootstrapComponentLibrary.TextColor.Primary => "primary",
                BootstrapComponentLibrary.TextColor.Secondary => "secondary",
                BootstrapComponentLibrary.TextColor.Success => "success",
                BootstrapComponentLibrary.TextColor.Danger => "danger",
                BootstrapComponentLibrary.TextColor.Warning => "warning",
                BootstrapComponentLibrary.TextColor.Info => "info",
                BootstrapComponentLibrary.TextColor.Light => "light",
                BootstrapComponentLibrary.TextColor.Dark => "dark",
                BootstrapComponentLibrary.TextColor.White => "white",
                BootstrapComponentLibrary.TextColor.Black => "black",
                _ => "primary"
            };
    }
}

public enum ButtonType
{
    Default,
    Button,
    Submit
}

public enum ButtonVariant
{
    Flat,
    Outlined
}

public enum ButtonColor
{
    Primary,
    Secondary,
    Success,
    Danger,
    Warning,
    Info,
    Light,
    Dark,
    Link
}

public enum ButtonSize
{
    Default,
    Large,
    Small
}