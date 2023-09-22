using BlazorPWA2.Interfaces;
using BlazorPWA2.Model;

namespace BlazorPWA2.Services;

public class ContactRepository : IContactRepository
{
    //TODO Create list of contacts in memory and save whole list even if only one entity is affected
    private readonly ILocalStorageService localStorageService;

    public ContactRepository(ILocalStorageService localStorageService)
    {
        this.localStorageService = localStorageService;
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        await localStorageService.RemoveAsync(id);
        var entity = await GetByIdAsync(id);
        return entity == null;
    }

    public Task<List<Contact>> GetAsync()
    {
        
    }

    public Task<Contact> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Contact> SaveAsync(Contact contact)
    {
        throw new NotImplementedException();
    }

}
