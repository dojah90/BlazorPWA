using BlazorPWA2.Interfaces;
using BlazorPWA2.Model;

namespace BlazorPWA2.Services;

public class ContactRepository : IContactRepository
{
    private readonly ILocalStorageService localStorageService;

    private List<Contact> contacts = new();

    public ContactRepository(ILocalStorageService localStorageService)
    {
        this.localStorageService = localStorageService;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var result = false;
        var contacts = await GetContacts();
        var contactsToDelete = contacts.Where(x => x.Id == id).ToList();

        if(contactsToDelete.Count() > 1)
        {
            throw new ArgumentException("Found multiple contacts with same id");
        }
        else if (contactsToDelete.Count() == 1)
        {
            foreach(var contact in contactsToDelete)
            {
                contacts.Remove(contact);
            }
            
            await localStorageService.SetAsync("contacts", contacts);
            result = true;
        }

        return result;
    }

    public async Task<List<Contact>> GetAsync()
    {
        return await GetContacts();
    }

    public async Task<Contact?> GetByIdAsync(Guid id)
    {
        return (await GetContacts())?.FirstOrDefault(x => x.Id == id);
    }

    public async Task<Contact> SaveAsync(Contact contact)
    {
        var contacts = await GetContacts();

        if(contact.Id == Guid.Empty)
        {
            contact.Id = Guid.NewGuid();
        }
        else
        {
            contacts.RemoveAll(x => x.Id == contact.Id);
        }

        contacts.Add(contact);
        await localStorageService.SetAsync("contacts", contacts);

        return contact;
    }

    private async Task<List<Contact>> GetContacts(){
        if(contacts == null || contacts.IsEmpty())
        {
            contacts = await localStorageService.GetAsync<List<Contact>>("contacts") ?? new();
        }
        return contacts;
    }

}
