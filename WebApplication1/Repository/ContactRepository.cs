using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactContext _context;

        public ContactRepository(ContactContext context)
        {
            _context = context;
        }

        public async Task<List<ContactModel>> GetAllContactsAsync()
        {
            var records = await _context.Contacts.Select(x => new ContactModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                NIC = x.NIC,
                MobileNo = x.MobileNo,
                EmailAddress = x.EmailAddress,
                Address = x.Address,
                Gender = x.Gender

            }).ToListAsync();

            return records;
        }

        public async Task<ContactModel> GetContactByIdAsync(int contactId)
        {
            var records = await _context.Contacts.Where(x => x.Id == contactId).Select(x => new ContactModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                NIC = x.NIC,
                MobileNo = x.MobileNo,
                EmailAddress = x.EmailAddress,
                Address = x.Address,
                Gender = x.Gender

            }).FirstOrDefaultAsync();

            return records;
        }

        public async Task<int> AddContactAsync(ContactModel contactModel)
        {

            var contact = new Contacts()
            {
                FirstName = contactModel.FirstName,
                LastName = contactModel.LastName,
                NIC = contactModel.NIC,
                EmailAddress = contactModel.EmailAddress,
                Address = contactModel.Address,
                MobileNo = contactModel.MobileNo,
                Gender = contactModel.Gender

            };

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return contact.Id;
        }

        public async Task  UpdateContactAsync(int contactId, ContactModel contactModel)
        {
            var contact = await _context.Contacts.FindAsync(contactId);

            if(contact != null)
            {
                contact.FirstName = contactModel.FirstName;
                contact.LastName = contactModel.LastName;
                contact.NIC = contactModel.NIC;
                contact.EmailAddress = contactModel.EmailAddress;
                contact.Address = contactModel.Address;
                contact.MobileNo = contactModel.MobileNo;
                contact.Gender = contactModel.Gender;

                await _context.SaveChangesAsync();
            }

          
            


        }


        public async Task  DeleteContactAsync(int contactId)
        {

            var contact = new Contacts() { Id = contactId };

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            
        }
    }
}
