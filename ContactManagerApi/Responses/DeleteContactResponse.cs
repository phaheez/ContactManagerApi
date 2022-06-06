using System.Text.Json.Serialization;

namespace ContactManagerApi.Responses
{
    public class DeleteContactResponse : BaseResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int ContactId { get; set; }
    }
}
