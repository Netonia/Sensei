using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Sensei;
using Sensei.Data;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient<JishoHttpClient>(client => client.BaseAddress = new Uri("https://jisho.org")); 
builder.Services.AddHttpClient("jisho", client =>  client.BaseAddress = new Uri("https://jisho.org"));

await builder.Build().RunAsync();
