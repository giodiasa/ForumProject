namespace Forum.Application.Identity
{
    public class LoginResponseDTO
    {
        public UserDto User { get; set; } = new UserDto();
        public string Token { get; set; } = string.Empty;

    }
}
