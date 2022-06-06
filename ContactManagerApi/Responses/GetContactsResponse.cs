using ContactManagerApi.Entities;

namespace ContactManagerApi.Responses
{
    public class GetContactsResponse : BaseResponse
    {
        public List<Contact> Contacts { get; set; }
    }
}
