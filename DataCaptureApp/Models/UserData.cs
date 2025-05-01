using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataCaptureApp.Models
{
    public class UserData
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        [RegularExpression(@"^(\+44\s?7\d{3}|\(?07\d{3}\)?)\s?\d{3}\s?\d{3}$",
            ErrorMessage = "Invalid phone number.")]
        public required string PhoneNumber { get; set; }

        [Required]
        public required string Address { get; set; }

        [Required]
        [RegularExpression(@"^(GIR\s?0AA|[A-PR-UWYZ][A-HK-Y]?[0-9][0-9A-HJKS-UW]? ?[0-9][ABD-HJLNP-UW-Z]{2})$",
            ErrorMessage = "Invalid postcode")]
        public required string Postcode { get; set; }

        [JsonIgnore]
        public string? SerializedJson { get; set; }

    }
}
