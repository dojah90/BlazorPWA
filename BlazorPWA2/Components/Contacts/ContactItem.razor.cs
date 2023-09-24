using System.Runtime.CompilerServices;
using BlazorBootstrap;
using BlazorPWA2.Interfaces;
using BlazorPWA2.Model;
using Microsoft.AspNetCore.Components;

namespace BlazorPWA2.Components.Contacts;

public partial class ContactItem
{
    [Inject] IContactRepository contactRepository { get; set; }
    [Inject] ModalService modalService { get; set; }
    [Parameter] public Contact Contact { get; set; }
    [Parameter] public EventCallback OnDelete { get; set; }

    private async Task Delete()
    {       
        if(OnDelete.HasDelegate){
            await OnDelete.InvokeAsync(Contact);
        }        
    }
}
