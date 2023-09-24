using BlazorPWA2.Interfaces;
using BlazorPWA2.Model;
using Microsoft.AspNetCore.Components;

namespace BlazorPWA2.Pages.Contacts;

public partial class ContactEditPage : ComponentBase
{
    [Inject] IContactRepository contactRepository { get; set; }
    [Inject] INavigationService navigationService { get; set; }
    
    private Contact contact;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        contact = new();
    }

    private async Task Save(){
        var savedContact = await contactRepository.SaveAsync(contact);
        if(savedContact != null)
        {
            navigationService.NavigateTo("/contacts");
        }
    }
}
