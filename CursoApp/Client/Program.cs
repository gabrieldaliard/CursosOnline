using CursoApp.Client.Services;
using CursoApp.Shared.DataBaseModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Radzen;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddHttpClient<iEntidadDataService<Cursos>, CursosDataService<Cursos>>(client => client.BaseAddress = new Uri("https://localhost:44341/"));
            builder.Services.AddHttpClient<iEntidadDataService<Instructores>, InstructorDataService<Instructores>>(client => client.BaseAddress = new Uri("https://localhost:44341/"));
            
            builder.Services.AddScoped<NotificationService>();
            
            await builder.Build().RunAsync();
        }
    }
}
