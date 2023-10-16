using BlazorPWA2.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorPWA2;

public partial class App : ComponentBase
{
    [CascadingParameter] public Blazored.Modal.Services.IModalService Modal { get; set; } = default!;
  
}
