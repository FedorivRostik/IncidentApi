using Core.Entities;
using Core.ViewModels.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.Interface;

namespace WebApi.AutoMapper.AccountMapper
{
    public class AccountToContactCreateMapper : IViewModelMapper<AccountCreateModel, Contact>
    {
        public Contact Map(AccountCreateModel source)
        {
          var contact = new Contact()
          {
              LastName = source.LastName,
              FirstName = source.FirstName,
              Email = source.Email
          };
            return contact;
        }
    }
}
