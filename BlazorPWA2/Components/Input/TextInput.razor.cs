using Microsoft.AspNetCore.Components;

namespace BlazorPWA2.Components.Input;

public partial class TextInput : ComponentBase
{
    [Parameter] public string Title { get; set; } = string.Empty;
    [Parameter] public string Placeholder { get; set; } = string.Empty;
    [Parameter] public string Value { get; set; } = string.Empty;
    
}
