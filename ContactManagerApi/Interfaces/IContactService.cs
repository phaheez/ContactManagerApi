using ContactManagerApi.Entities;
using ContactManagerApi.Requests;
using ContactManagerApi.Responses;

namespace ContactManagerApi.Interfaces
{
    public interface IContactService
    {
        Task<GetContactsResponse> GetContacts(int userId);
        Task<SaveContactResponse> SaveContact(Contact contact);
        Task<DeleteContactResponse> DeleteContact (int contactId, int userId);
        Task<UpdateContactResponse> UpdateContact(int contactId, int userId, UpdateContactRequest model);
    }
}
