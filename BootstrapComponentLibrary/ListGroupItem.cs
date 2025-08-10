using Microsoft.AspNetCore.Components;

namespace BootstrapComponentLibrary;

public class ListGroupItem : CompBase
{
    [Parameter] public RenderFragment? ChildContent { get; set; }

    [CascadingParameter]
    public ListGroup Parent
    {
        get => _listGroup;
        set
        {
            if(_listGroup == value) return;
            _listGroup = value;
            _listGroup.AddItem(this);
        }
    }

    private ListGroup _listGroup = null!;
}