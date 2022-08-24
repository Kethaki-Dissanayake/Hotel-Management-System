using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IContactRepository
    {
        Task<List<ContactModel>> GetAllContactsAsync();
        Task<ContactModel> GetContactByIdAsync(int contactId);
        Task<int> AddContactAsync(ContactModel contactModel);

        Task UpdateContactAsync(int contactId, ContactModel contactModel);
        Task DeleteContactAsync(int contactId);
        }
}
