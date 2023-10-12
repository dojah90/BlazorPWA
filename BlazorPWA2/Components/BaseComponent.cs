using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorPWA2;

public abstract class BaseComponent : ComponentBase
{
    [Inject] public IJSRuntime JSRuntime { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (firstRender == true)
        {
            //await JSRuntime.InvokeVoidAsync("fadeIn");
        }
    }
}
