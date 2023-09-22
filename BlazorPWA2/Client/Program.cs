using BlazorPWA2;
using BlazorPWA2.Interfaces;
using BlazorPWA2.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorPWA2
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            IServiceCollection services = builder.Services;
            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            AddServices(services);

            await builder.Build().RunAsync();
        }

        private static void AddServices(IServiceCollection services){
            services.AddScoped<INavigationService, NavigationService>()
            .AddScoped<ILocalStorageService, LocalStorageService>();
        }
    }
}