using Core.Entities;
using Core.ViewModels.IncidentViewModels;
using WebApi.AutoMapper.Interface;

namespace WebApi.AutoMapper.IncidentMapper
{
    public class IncidentToContactCreateMapper : IViewModelMapper<IncidentCreateModel, Contact>
    {
        public Contact Map(IncidentCreateModel source)
        {
            var contact = new Contact()
            {
                FirstName=source.FirstName,
                LastName=source.LastName,
                Email=source.Email
            };
            return contact;
        }
    }
}
