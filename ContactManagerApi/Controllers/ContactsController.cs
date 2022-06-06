using ContactManagerApi.Entities;
using ContactManagerApi.Interfaces;
using ContactManagerApi.Requests;
using ContactManagerApi.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagerApi.Controllers
{
    [Authorize]
    [Route("api/contact")]
    [ApiController]
    public class ContactsController : BaseApiController
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> Get()
        {
            var getContactsResponse = await _contactService.GetContacts(UserID);

            if (!getContactsResponse.Success)
            {
                return UnprocessableEntity(getContactsResponse);
            }

            var contactsResponse = getContactsResponse.Contacts.ConvertAll(o => new ContactResponse 
            { 
                Id = o.Id,
                Name = o.Name,
                Mobile = o.Mobile,
                Email = o.Email,
                PhotoUrl = o.PhotoUrl,
                Company = o.Company,
                Address = o.Address,
                Designation = o.Designation.Name,
                DesignationId = o.DesignationId,
                CreatedDate = o.CreatedDate 
            });

            return Ok(contactsResponse);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post(ContactRequest contactRequest)
        {
            var contact = new Contact 
            { 
                UserId = UserID,
                DesignationId = contactRequest.DesignationId,
                Name = contactRequest.Name,
                Mobile = contactRequest.Mobile,
                Email = contactRequest.Email,
                PhotoUrl = contactRequest.PhotoUrl,
                Company = contactRequest.Company,
                Address = contactRequest.Address,
                CreatedDate = DateTime.Now   
            };

            var saveContactResponse = await _contactService.SaveContact(contact);

            if (!saveContactResponse.Success)
            {
                return UnprocessableEntity(saveContactResponse);
            }

            var contactResponse = new ContactResponse
            {
                Id = saveContactResponse.Contact.Id,
                Name = saveContactResponse.Contact.Name,
                Mobile = saveContactResponse.Contact.Mobile,
                Email = saveContactResponse.Contact.Email,
                PhotoUrl = saveContactResponse.Contact.PhotoUrl,
                Company = saveContactResponse.Contact.Company,
                Address = saveContactResponse.Contact.Address,
                DesignationId = saveContactResponse.Contact.DesignationId,
                CreatedDate = saveContactResponse.Contact.CreatedDate
            };

            return Ok(contactResponse);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, UpdateContactRequest contactRequest)
        {
            //var contact = new Contact
            //{
            //    DesignationId = contactRequest.DesignationId,
            //    Name = contactRequest.Name,
            //    Mobile = contactRequest.Mobile,
            //    Email = contactRequest.Email,
            //    PhotoUrl = contactRequest.PhotoUrl,
            //    Company = contactRequest.Company,
            //    Address = contactRequest.Address
            //};

            var updateContactResponse = await _contactService.UpdateContact(id, UserID, contactRequest);

            if (!updateContactResponse.Success)
            {
                return UnprocessableEntity(updateContactResponse);
            }

            var contactResponse = new ContactResponse
            {
                Id = updateContactResponse.Contact.Id,
                Name = updateContactResponse.Contact.Name,
                Mobile = updateContactResponse.Contact.Mobile,
                Email = updateContactResponse.Contact.Email,
                PhotoUrl = updateContactResponse.Contact.PhotoUrl,
                Company = updateContactResponse.Contact.Company,
                Address = updateContactResponse.Contact.Address,
                DesignationId = updateContactResponse.Contact.DesignationId,
                CreatedDate = updateContactResponse.Contact.CreatedDate
            };

            return Ok(contactResponse);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteContactResponse = await _contactService.DeleteContact(id, UserID);
            if (!deleteContactResponse.Success)
            {
                return UnprocessableEntity(deleteContactResponse);
            }

            return Ok(deleteContactResponse.ContactId);
        }
    }
}
