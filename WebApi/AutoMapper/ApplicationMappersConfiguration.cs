using Core.Entities;
using Core.ViewModels.AccountViewModels;
using Core.ViewModels.ContactViewModels;
using Core.ViewModels.IncidentViewModels;
using Microsoft.Extensions.DependencyInjection;
using WebApi.AutoMapper.AccountMapper;
using WebApi.AutoMapper.ContactMapper;
using WebApi.AutoMapper.IncidentMapper;
using WebApi.AutoMapper.Interface;

namespace WebApi.AutoMapper
{
    public static class ApplicationMappersConfiguration
    {
        public static void AddApplicationMappers(this IServiceCollection services)
        {
            services.AddScoped<IViewModelMapper<ContactCreateModel, Contact>, ContactCreateMapper>();

            services.AddScoped<IViewModelMapper<AccountCreateModel, Account>, AccountCreateMapper>();
            services.AddScoped<IViewModelMapper<AccountCreateModel, Contact>, AccountToContactCreateMapper>();

            services.AddScoped<IViewModelMapper<IncidentCreateModel, Account>, IncidentToAccountCreateMapper>();
            services.AddScoped<IViewModelMapper<IncidentCreateModel, Contact>, IncidentToContactCreateMapper>();
            services.AddScoped<IViewModelMapper<IncidentCreateModel, Incident>, IncidentCreateMapper>();
        }
    }
}
