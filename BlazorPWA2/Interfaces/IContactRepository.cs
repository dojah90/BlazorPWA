using BlazorPWA2.Model;

namespace BlazorPWA2.Interfaces;

public interface IContactRepository
{
    Task<Contact?> GetByIdAsync(Guid id);
    Task<List<Contact>> GetAsync();
    Task<Contact> SaveAsync(Contact contact);
    Task<bool> DeleteAsync(Guid id);
}
