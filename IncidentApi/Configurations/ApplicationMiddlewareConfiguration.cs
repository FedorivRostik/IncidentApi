using FluentValidation.AspNetCore;
using WebApi.Validators.ContactValidators;

namespace Host.Configurations
{
    public static class SystemServicesConfiguration
    {

        public static void AddSystemServices(this IServiceCollection services)
        {


            services
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
            
           
        }
    }
}
