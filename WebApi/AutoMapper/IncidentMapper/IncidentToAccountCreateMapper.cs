using Core.Entities;
using Core.ViewModels.IncidentViewModels;
using WebApi.AutoMapper.Interface;

namespace WebApi.AutoMapper.IncidentMapper
{
    public class IncidentToAccountCreateMapper : IViewModelMapper<IncidentCreateModel, Account>
    {
        public Account Map(IncidentCreateModel source)
        {
            var account = new Account()
            {
                Name = source.Name
            };
            return account;
        }
    }
}
