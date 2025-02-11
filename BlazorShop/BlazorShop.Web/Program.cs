using BlazorShop.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
string url = "http://localhost:5154";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(url) });

await builder.Build().RunAsync();
