using Core.Entities;
using Core.Interfaces.Repositories;
using Core.ViewModels.IncidentViewModels;
using Microsoft.AspNetCore.Mvc;
using WebApi.AutoMapper.Interface;

namespace WebApi.Controllers
{
    [Route("api/incidents")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        public IncidentController(
            IIncidentRepository repository,
             IViewModelMapper<IncidentCreateModel, Account> accountCreateMapper,
             IViewModelMapper<IncidentCreateModel, Contact> contactCreateMapper,
             IViewModelMapper<IncidentCreateModel, Incident> incidentCreateMapper)
        {
            _repository = repository;
            _accountCreateMapper = accountCreateMapper;
            _contactCreateMapper = contactCreateMapper;
            _incidentCreateMapper = incidentCreateMapper;
        }

        private readonly IIncidentRepository _repository;
        private readonly IViewModelMapper<IncidentCreateModel, Account> _accountCreateMapper;
        private readonly IViewModelMapper<IncidentCreateModel, Contact> _contactCreateMapper;
        private readonly IViewModelMapper<IncidentCreateModel, Incident> _incidentCreateMapper;

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] IncidentCreateModel model)
        {
            var incident = _incidentCreateMapper.Map(model);
            var account = _accountCreateMapper.Map(model);
            var contact = _contactCreateMapper.Map(model);

            await _repository.CreateAsync(incident, account, contact);

            return CreatedAtAction(nameof(CreateAsync), new { accountId = account.Id, contactId = contact.Id, incidentId = incident.Name });
        }
    }
}
