using Forum.Core.Interfaces;
using Forum.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Forum.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void DeleteUser(IdentityUser entity)
        {
            if (entity != null)
            {
                _context.Users.Remove(entity);
            }
        }

        public async Task<List<IdentityUser>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<List<IdentityUser>> GetAllUsersAsync(Expression<Func<IdentityUser, bool>> filter)
        {
            return await _context.Users.Where(filter).ToListAsync();
        }

        public async Task<IdentityUser?> GetSingleUserAsync(Expression<Func<IdentityUser, bool>> filter)
        {
            return await _context.Users.FirstOrDefaultAsync(filter);
        }

        public async Task Save() => await _context.SaveChangesAsync();

        public async Task UpdateUserAsync(IdentityUser entity)
        {
            if (entity != null)
            {
                var userToUpdate = await _context.Users.FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (userToUpdate != null)
                {
                    userToUpdate.Email = entity.Email;
                    userToUpdate.PhoneNumber = entity.PhoneNumber;
                    userToUpdate.UserName = entity.UserName;
                    userToUpdate.NormalizedEmail = entity.NormalizedEmail;
                    userToUpdate.NormalizedUserName = entity.NormalizedUserName;

                    _context.Users.Update(userToUpdate);
                }
            }
        }
    }
}
