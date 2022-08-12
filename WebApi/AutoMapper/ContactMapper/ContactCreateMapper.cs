using Core.Entities;
using Core.ViewModels.ContactViewModels;
using WebApi.AutoMapper.Interface;

namespace WebApi.AutoMapper.ContactMapper
{
    public class ContactCreateMapper : IViewModelMapper<ContactCreateModel, Contact>
    {
        public Contact Map(ContactCreateModel source)
        {
           var contact = new Contact()
           {
               FirstName = source.FirstName,
               LastName = source.LastName,
               Email = source.Email
           };
            return contact;
        }
    }
}
