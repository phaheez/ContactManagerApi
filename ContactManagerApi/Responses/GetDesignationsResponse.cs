using ContactManagerApi.Entities;

namespace ContactManagerApi.Responses
{
    public class GetDesignationsResponse : BaseResponse
    {
        public List<Designation> Designations { get; set; }
    }
}
