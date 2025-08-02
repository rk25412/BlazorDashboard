using Microsoft.AspNetCore.Components;

namespace BootstrapComponentLibrary;

public class AccordionItem : CompBase
{
    [CascadingParameter]
    public Accordion Accordion
    {
        get => _accordion;
        set
        {
            if (_accordion == value) return;
            _accordion = value;
            _accordion.AddItem(this);
        }
    }

    [Parameter] public string Title { get; set; } = string.Empty;
    [Parameter] public RenderFragment? ChildContent { get; set; }
    private Accordion _accordion = null!;
    public bool Expanded { get; set; } = false;
    public string ContentId { get; } = Guid.NewGuid().ToString();
    public Dictionary<string, object> ContentAttributes { get; set; } = [];

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (_accordion.Multiple is false)
        {
            ContentAttributes.Add("data-bs-parent", $"#{_accordion.GetId()}");
        }
    }
}