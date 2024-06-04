using Forum.Application.Identity;

namespace Forum.Application.Interfaces
{
    public interface IAuthService
    {
        Task Register(RegistrationRequestDTO registrationRequestDto);
        Task RegisterAdmin(RegistrationRequestDTO registrationRequestDto);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto);
        string GetAuthenticatedUserId();
        string GetAuthenticatedUserRole();
    }
}
