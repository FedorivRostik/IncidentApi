using Core.Entities;
using Core.Interfaces.Services;
using Core.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Mvc;
using WebApi.AutoMapper.Interface;

namespace WebApi.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountController(
            IAccountService service,
            IViewModelMapper<AccountCreateModel, Account> accountMapper,
            IViewModelMapper<AccountCreateModel, Contact> contactMapper)
        {
            _accountMapper = accountMapper;
            _contactMapper = contactMapper;
            _service = service;
        }

        private readonly IViewModelMapper<AccountCreateModel, Account> _accountMapper;
        private readonly IViewModelMapper<AccountCreateModel, Contact> _contactMapper;
        private readonly IAccountService _service;

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AccountCreateModel model)
        {
            var account = _accountMapper.Map(model);
            var contact = _contactMapper.Map(model);

            await _service.CreateAsync(account, contact);

            return CreatedAtAction(nameof(CreateAsync), new { accountId = account.Id, contactId=contact.Id });
        }
    }
}
