using BlazorBootstrap;
using Blazored.Modal;
using Blazored.Modal.Services;
using BlazorPWA2.Interfaces;
using BlazorPWA2.Modal;
using BlazorPWA2.Model;
using BlazorPWA2.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorPWA2.Pages.Contacts;

public partial class ContactsPage : ComponentBase
{
    [Inject] public IContactRepository ContactRepository { get; set; }
    [Inject] IModalService modalService { get; set; }
    [Inject] INavigationService navigationService { get; set; }
    [Inject] ILogger<ContactsPage> logger {get;set;}


    public List<Contact> ContactList { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (ContactRepository != null)
        {
            ContactList = await ContactRepository.GetAsync();
        }
    }

    private async Task AddContact()
    {
        navigationService.NavigateTo("/contacts/edit");
    }

    private async void OnDeleteClicked(Contact? contact)
    {
        if (contact != null)
        {
            var modal = modalService.Show(typeof(YesNoModal));
            var result = await modal.Result;

            if (result.Confirmed)
            {
                try
                {
                    await ContactRepository.DeleteAsync(contact.Id);
                    ContactList.Remove(contact);
                    StateHasChanged();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                }
            }

        }
    }
}
