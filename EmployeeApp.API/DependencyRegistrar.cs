using EmployeeApp.API.Services;
using EmployeeApp.API.Services.Interfaces;

namespace EmployeeApp.API;

public static class DependencyRegistrar
{
    public static IServiceCollection ConfigureDependencies(
        this IServiceCollection services)
    {
        services.ConfigureServices();

        return services;
    }
    
    public static IServiceCollection ConfigureServices(
        this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();

        return services;
    }
}