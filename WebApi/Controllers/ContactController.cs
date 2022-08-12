using Core.Entities;
using Core.Interfaces.Services;
using Core.ViewModels.ContactViewModels;
using Microsoft.AspNetCore.Mvc;
using WebApi.AutoMapper.Interface;

namespace WebApi.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        public ContactController(
            IViewModelMapper<ContactCreateModel, Contact> createMapper,
            IContactService service)
        {
            _createMapper = createMapper;
            _service = service;
        }

        private readonly IViewModelMapper<ContactCreateModel, Contact> _createMapper;
        private readonly IContactService _service;

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ContactCreateModel createModel)
        {
            var contact = _createMapper.Map(createModel);
            await _service.CreateAsync(contact);
            return CreatedAtAction(nameof(CreateAsync), new { id = contact.Id });
        }

    }
}
