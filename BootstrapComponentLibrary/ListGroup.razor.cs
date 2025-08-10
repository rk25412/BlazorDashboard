using Microsoft.AspNetCore.Components;

namespace BootstrapComponentLibrary;

public partial class ListGroup
{
    [Parameter, EditorRequired] public RenderFragment? Items { get; set; }
    
    private readonly List<ListGroupItem> _items = [];

    public void AddItem(ListGroupItem item)
    {
        _items.Add(item);
        InvokeAsync(StateHasChanged);
    }

    public void RemoveItem(ListGroupItem item)
    {
        _items.Remove(item);
        InvokeAsync(StateHasChanged);
    }
}