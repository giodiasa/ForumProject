using Microsoft.AspNetCore.Identity;

namespace Forum.Application.Interfaces
{
    public interface IJwtGenerator
    {
        string GenerateJwtToken(IdentityUser identityUser, IEnumerable<string> roles);
    }
}
