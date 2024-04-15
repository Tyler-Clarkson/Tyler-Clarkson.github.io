using DotNetNuke.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Swbc.Modules.AdValoremSwivel.Components;

public class Startup : IDnnStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IDataInit, DataInit>();
    }
}
