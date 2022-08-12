using Core.Entities;
using Core.ViewModels.IncidentViewModels;
using WebApi.AutoMapper.Interface;

namespace WebApi.AutoMapper.IncidentMapper
{
    public class IncidentCreateMapper : IViewModelMapper<IncidentCreateModel, Incident>
    {
        public Incident Map(IncidentCreateModel source)
        {
            var incident = new Incident()
            {
                Description = source.Description
            };
            return incident;
        }
    }
}
