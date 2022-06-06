using System.ComponentModel.DataAnnotations;

namespace ContactManagerApi.Requests
{
    public class UpdateContactRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhotoUrl { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int DesignationId { get; set; }
    }
}
