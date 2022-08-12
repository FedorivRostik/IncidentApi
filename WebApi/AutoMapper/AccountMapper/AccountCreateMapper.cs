using Core.Entities;
using Core.ViewModels.AccountViewModels;
using WebApi.AutoMapper.Interface;

namespace WebApi.AutoMapper.AccountMapper
{
    public class AccountCreateMapper : IViewModelMapper<AccountCreateModel, Account>
    {
        public Account Map(AccountCreateModel source)
        {
            var account = new Account()
            {
                Name=source.Name
            };
            return account;
        }
    }
}
