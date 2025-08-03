using Microsoft.AspNetCore.Components;

namespace BootstrapComponentLibrary;

public partial class Card
{
    [Parameter, EditorRequired] public required RenderFragment CardBody { get; set; }
    [Parameter] public RenderFragment? CardHeader { get; set; }
    [Parameter] public RenderFragment? CardFooter { get; set; }
    [Parameter] public string? Title { get; set; }
    [Parameter] public string? Subtitle { get; set; }
    [Parameter] public string? ImgTop { get; set; }
    [Parameter] public string? ImgBottom { get; set; }
    [Parameter] public bool ImageOverlay { get; set; }
}