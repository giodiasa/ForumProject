using Forum.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Forum.Core.Interfaces
{
    public interface IUserRepository : ISavable
    {
        Task<List<IdentityUser>> GetAllUsersAsync();
        Task<List<IdentityUser>> GetAllUsersAsync(Expression<Func<IdentityUser, bool>> filter);
        Task<IdentityUser?> GetSingleUserAsync(Expression<Func<IdentityUser, bool>> filter);
        Task UpdateUserAsync(IdentityUser entity);
        void DeleteUser(IdentityUser entity);
    }
}
