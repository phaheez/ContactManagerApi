namespace ContactManagerApi.Responses
{
    public class ContactResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public int DesignationId { get; set; }
        public string Designation { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
