namespace DataCaptureApp.Models
{
    public class UserData
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }
        public required string Postcode { get; set; }
    }
}