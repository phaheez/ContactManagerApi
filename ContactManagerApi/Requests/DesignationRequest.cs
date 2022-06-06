using System.ComponentModel.DataAnnotations;

namespace ContactManagerApi.Requests
{
    public class DesignationRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
