using Microsoft.AspNetCore.Components;

namespace BlazorPWA2.Components;

public partial class ActionButton
{
    [Parameter]
    public Action? Action { get; set; }


}
