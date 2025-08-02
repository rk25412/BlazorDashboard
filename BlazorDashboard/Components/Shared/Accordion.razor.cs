using Microsoft.AspNetCore.Components;

namespace BlazorDashboard.Components.Shared;

public partial class Accordion
{
    [Parameter, EditorRequired] public RenderFragment? Items { get; set; }
    [Parameter] public bool Multiple { get; set; }
    [Parameter] public bool Flush { get; set; }
    [Parameter] public EventCallback<int> OnExpand { get; set; }
    [Parameter] public EventCallback<int> OnCollapse { get; set; }
    [Parameter] public int? ExpandedIndex { get; set; }
    private int? _expandedIndex;
    private readonly List<AccordionItem> _items = [];

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _expandedIndex = ExpandedIndex;
    }

    public void AddItem(AccordionItem accordionItem)
    {
        _items.Add(accordionItem);
        accordionItem.Expanded = _items.IndexOf(accordionItem) == _expandedIndex;
        InvokeAsync(StateHasChanged);
    }

    public void RemoveItem(AccordionItem accordionItem)
    {
        _items.Remove(accordionItem);
        _expandedIndex = null;
        InvokeAsync(StateHasChanged);
    }

    private void OnHeaderClick(AccordionItem item)
    {
        var index = _items.IndexOf(item);
        var expandedItem = _expandedIndex is not null ? _items[_expandedIndex.Value] : null;

        if (expandedItem is not null && !Multiple)
        {
            ToggleExpand(expandedItem);
        }

        ToggleExpand(item);

        _expandedIndex = item.Expanded ? index : null;

        if (!Multiple)
        {
            _items.ForEach(i => i.Expanded = _items.IndexOf(i) == _expandedIndex);
        }
    }

    private void ToggleExpand(AccordionItem item)
    {
        var index = _items.IndexOf(item);
        if (item.Expanded)
        {
            OnCollapse.InvokeAsync(index);
            item.Expanded = false;
        }
        else
        {
            OnExpand.InvokeAsync(index);
            item.Expanded = true;
        }
    }

    public async Task ExpandAll()
    {
        var collapsedItems = _items.Where(i => !i.Expanded).ToList();
        List<Task> tasks = [];
        collapsedItems.ForEach(x => tasks.Add(Task.Run(() => ToggleExpand(x))));
        await Task.WhenAll(tasks);
    }

    public async Task CollapseAll()
    {
        var expandedItems = _items.Where(i => i.Expanded).ToList();
        List<Task> tasks = [];
        expandedItems.ForEach(x => tasks.Add(Task.Run(() => ToggleExpand(x))));
        await Task.WhenAll(tasks);
    }
}