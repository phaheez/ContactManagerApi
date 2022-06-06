using ContactManagerApi.Entities;

namespace ContactManagerApi.Responses
{
    public class UpdateContactResponse : BaseResponse
    {
        public Contact Contact { get; set; }
    }
}
