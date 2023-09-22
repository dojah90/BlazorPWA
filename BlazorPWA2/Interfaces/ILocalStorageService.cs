namespace BlazorPWA2.Interfaces;

public interface ILocalStorageService
{
    Task SetAsync<T>(string key, T value);
    Task RemoveAsync(string key);
    Task RemoveAsync<T>(T key);
    Task<T?> GetAsync<T>(string key);
    Task Clear();
}
