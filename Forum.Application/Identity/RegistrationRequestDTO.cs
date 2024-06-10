using System.ComponentModel.DataAnnotations;

namespace Forum.Application.Identity
{
    public class RegistrationRequestDTO
    {
        public string UserName { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
