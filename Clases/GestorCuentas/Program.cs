using GestorCuentas;
using GestorCuentas.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<BrowserPersistence>();
builder.Services.AddScoped<GestorDeCuentas>();
builder.Services.AddScoped<Sesion>();

await builder.Build().RunAsync();
