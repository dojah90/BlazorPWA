using BlazorBootstrap;
using BlazorPWA2.Interfaces;
using BlazorPWA2.Model;
using BlazorPWA2.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorPWA2.Pages.Contacts;

public partial class ContactsPage : ComponentBase
{
    [Inject] public IContactRepository ContactRepository { get; set; }
    [Inject] ModalService modalService { get; set; }
    [Inject] INavigationService navigationService { get; set; }
    

    public List<Contact> ContactList { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if(ContactRepository != null)
        {
            ContactList = await ContactRepository.GetAsync();
        }
    }

    private async Task AddContact()
    {
        navigationService.NavigateTo("/contacts/edit");
    }

    private async void OnDeleteClicked(Contact? contact){
        if(contact != null){
            try{
                await ContactRepository.DeleteAsync(contact.Id);
                ContactList.Remove(contact);
            }
            catch (Exception ex){
                var modalOption = new ModalOption{
                    Title = "Kontakt konnte nicht gelöscht werden",
                    Message = ex.Message,
                    Type = ModalType.Danger
                };

                await modalService.ShowAsync(modalOption);
            }
        }
    }
}
