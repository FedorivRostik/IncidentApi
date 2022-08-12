using Core.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services
{
    public static class ApplicationServicesConfiguration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IIncidentService, IncidentService>();
            
        }
    }
}
