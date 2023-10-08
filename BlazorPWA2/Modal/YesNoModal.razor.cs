using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorPWA2.Modal;

public partial class YesNoModal
{
    [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; } = default!;
    private async void Ok(){
        await BlazoredModal.CloseAsync(ModalResult.Ok());
    }

    private async void Cancel(){
        await BlazoredModal.CloseAsync(ModalResult.Cancel());
    }
}
