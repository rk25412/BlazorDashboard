using Microsoft.AspNetCore.Components;

namespace BootstrapComponentLibrary;

public partial class Accordion
{
    /// <summary>
    /// Accordion Items
    /// </summary>
    [Parameter, EditorRequired] public RenderFragment? Items { get; set; }
    
    /// <summary>
    /// Indicates whether multiple items can be expanded at once
    /// </summary>
    [Parameter] public bool Multiple { get; set; }
    
    /// <summary>
    /// Set true to remove some borders and rounded corners to render accordions edge-to-edge with their parent container.
    /// </summary>
    [Parameter] public bool Flush { get; set; }
    
    /// <summary>
    /// Event callback for when an item is expanded
    /// </summary>
    [Parameter] public EventCallback<int> OnExpand { get; set; }
    
    /// <summary>
    /// Event callback when an item is collapsed
    /// </summary>
    [Parameter] public EventCallback<int> OnCollapse { get; set; }
    
    /// <summary>
    /// Index of the item which should already be expanded on the first load
    /// </summary>
    [Parameter] public int? ExpandedIndex { get; set; }
    private int? _expandedIndex;
    private readonly List<AccordionItem> _items = [];

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _expandedIndex = ExpandedIndex;
    }

    /// <summary>
    /// Adds an accordion item to the accordion
    /// </summary>
    /// <param name="accordionItem"></param>
    public void AddItem(AccordionItem accordionItem)
    {
        _items.Add(accordionItem);
        accordionItem.Expanded = _items.IndexOf(accordionItem) == _expandedIndex;
        InvokeAsync(StateHasChanged);
    }

    /// <summary>
    /// Removes and accordion item from the accordion
    /// </summary>
    /// <param name="accordionItem"></param>
    public void RemoveItem(AccordionItem accordionItem)
    {
        _items.Remove(accordionItem);
        _expandedIndex = null;
        InvokeAsync(StateHasChanged);
    }

    /// <summary>
    /// Triggers when an item is expanded or collapsed
    /// </summary>
    /// <param name="item"></param>
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

    /// <summary>
    /// Toggle an expanded or unexpanded item
    /// </summary>
    /// <param name="item"></param>
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

    /// <summary>
    /// Expands all the items
    /// </summary>
    public async Task ExpandAll()
    {
        var collapsedItems = _items.Where(i => !i.Expanded).ToList();
        List<Task> tasks = [];
        collapsedItems.ForEach(x => tasks.Add(Task.Run(() => ToggleExpand(x))));
        await Task.WhenAll(tasks);
    }

    /// <summary>
    /// Collapses all the items
    /// </summary>
    public async Task CollapseAll()
    {
        var expandedItems = _items.Where(i => i.Expanded).ToList();
        List<Task> tasks = [];
        expandedItems.ForEach(x => tasks.Add(Task.Run(() => ToggleExpand(x))));
        await Task.WhenAll(tasks);
    }
}