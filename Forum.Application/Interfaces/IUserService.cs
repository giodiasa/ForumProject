using Forum.Application.DTOs;
using Forum.Application.Identity;
using Microsoft.AspNetCore.JsonPatch;

namespace Forum.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetSingleUserByEmailAsync(string email);
        Task UpdateUserAsync(UserDto model);
        Task DeleteUserAsync(string Id);
        Task UpdateUserAsync(string userId, JsonPatchDocument<UserDto> patchDocument);
    }
}
