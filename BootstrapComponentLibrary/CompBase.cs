using Microsoft.AspNetCore.Components;

namespace BootstrapComponentLibrary;

public class CompBase : ComponentBase
{
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> Attributes { get; set; } = [];
    
    /// <summary>
    /// Custom classes for the element
    /// </summary>
    [Parameter] public string Class { get; set; } = "";
    
    /// <summary>
    /// Trigger when clicked
    /// </summary>
    [Parameter] public EventCallback OnClick { get; set; }
    
    /// <summary>
    /// Indicated whether the component is visible
    /// </summary>
    [Parameter] public bool Visible { get; set; } = true;
    
    /// <summary>
    /// Element Reference for the component
    /// </summary>
    public ElementReference? ElementReference { get; set; }
    
    private string UniqueId { get; set; } = string.Empty;
    
    protected override void OnInitialized()
    {
        UniqueId = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("/", "-").Replace("+", "-").Substring(0, 10);
    }

    /// <summary>
    /// Gets ID for an item
    /// </summary>
    /// <returns></returns>
    public virtual string GetId()
    {
        return Attributes.TryGetValue("id", out var id) ? $"{@id}" : UniqueId;
    }
}