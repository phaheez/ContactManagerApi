using ContactManagerApi.Entities;

namespace ContactManagerApi.Responses
{
    public class SaveContactResponse : BaseResponse
    {
        public Contact Contact { get; set; }
    }
}
