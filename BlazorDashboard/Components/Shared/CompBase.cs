using Microsoft.AspNetCore.Components;

namespace BlazorDashboard.Components.Shared;

public class CompBase : ComponentBase
{
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> Attributes { get; set; } = [];
    [Parameter] public string Class { get; set; } = "";
    [Parameter] public EventCallback OnClick { get; set; }
    [Parameter] public bool Visible { get; set; } = true;
    public ElementReference? ElementReference { get; set; }
    private string UniqueId { get; set; } = string.Empty;
    
    protected override void OnInitialized()
    {
        UniqueId = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("/", "-").Replace("+", "-").Substring(0, 10);
    }

    public virtual string GetId()
    {
        return Attributes.TryGetValue("id", out var id) ? $"{@id}" : UniqueId;
    }
}