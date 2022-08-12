using Core.Entities;
using Core.ViewModels.AccountViewModels;
using Core.ViewModels.IncidentViewModels;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Validators.AccountValidators;
using WebApi.Validators.ContactValidators;
using WebApi.Validators.IncidentValidators;

namespace WebApi.Validators
{
    public static class ApplicationValidationsConfiguration
    {
        public static void AddValidations(this IServiceCollection service)
        {
            service.AddScoped<IValidator<AccountCreateModel>, AccountValidator>();
            service.AddScoped<IValidator<Contact>, ContactValidator>();
            service.AddScoped<IValidator<IncidentCreateModel>, IncidentValidator>();
        }
    }
}
