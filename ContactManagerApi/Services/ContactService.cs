using ContactManagerApi.Entities;
using ContactManagerApi.Interfaces;
using ContactManagerApi.Requests;
using ContactManagerApi.Responses;
using Microsoft.EntityFrameworkCore;

namespace ContactManagerApi.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactsDbContext _context;

        public ContactService(ContactsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<DeleteContactResponse> DeleteContact(int contactId, int userId)
        {
            var contact = await _context.Contacts.FindAsync(contactId);

            if (contact == null)
            {
                return new DeleteContactResponse
                {
                    Success = false,
                    Error = "Contact not found",
                    ErrorCode = "T01"
                };
            }

            if (contact.UserId != userId)
            {
                return new DeleteContactResponse
                {
                    Success = false,
                    Error = "You don't have access to delete this contact",
                    ErrorCode = "T02"
                };
            }

            _context.Contacts.Remove(contact);

            var saveResponse = await _context.SaveChangesAsync();

            if (saveResponse >= 0)
            {
                return new DeleteContactResponse
                {
                    Success = true,
                    ContactId = contact.Id
                };
            }

            return new DeleteContactResponse
            {
                Success = false,
                Error = "Unable to delete task",
                ErrorCode = "T03"
            };
        }

        public async Task<GetContactsResponse> GetContacts(int userId)
        {
            var contacts = await _context.Contacts.AsNoTracking().Include(p => p.Designation).Where(o => o.UserId == userId).ToListAsync();

            return new GetContactsResponse { Success = true, Contacts = contacts };
        }

        public async Task<SaveContactResponse> SaveContact(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);

            var saveResponse = await _context.SaveChangesAsync();

            if (saveResponse >= 0)
            {
                return new SaveContactResponse
                {
                    Success = true,
                    Contact = contact
                };
            }
            return new SaveContactResponse
            {
                Success = false,
                Error = "Unable to save contact",
                ErrorCode = "T05"
            };
        }

        public async Task<UpdateContactResponse> UpdateContact(int contactId, int userId, UpdateContactRequest model)
        {
            var contact = await _context.Contacts.FindAsync(contactId);

            if (contact == null)
            {
                return new UpdateContactResponse
                {
                    Success = false,
                    Error = "Contact not found",
                    ErrorCode = "T01"
                };
            }

            if (contact.UserId != userId)
            {
                return new UpdateContactResponse
                {
                    Success = false,
                    Error = "You don't have access to update this contact",
                    ErrorCode = "T02"
                };
            }

            contact.Name = model.Name;
            contact.Email = model.Email;
            contact.Address = model.Address;
            contact.Mobile = model.Mobile;
            contact.Company = model.Company;
            contact.PhotoUrl = model.PhotoUrl;
            contact.DesignationId = model.DesignationId;

            _context.Entry(contact).State = EntityState.Modified;

            var updateResponse = await _context.SaveChangesAsync();

            if (updateResponse >= 0)
            {
                return new UpdateContactResponse
                {
                    Success = true,
                    Contact = contact
                };
            }

            return new UpdateContactResponse
            {
                Success = false,
                Error = "Unable to update contact",
                ErrorCode = "T05"
            };
        }
    }
}
