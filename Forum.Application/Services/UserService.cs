using AutoMapper;
using Forum.Application.Identity;
using Forum.Application.Interfaces;
using Forum.Core.Common.Exceptions;
using Forum.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Forum.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public UserService(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _mapper = MappingInitializer.Initialize();
            _authService = authService;
        }
        public async Task DeleteUserAsync(string Id)
        {
            if (Id == null) throw new ArgumentNullException("Invalid argument passed");
            var user = await _userRepository.GetSingleUserAsync(x => x.Id == Id);
            if (user == null) throw new UserNotFoundException();
            if (_authService.GetAuthenticatedUserRole() != "Admin")
            {
                throw new UnauthorizedAccessException("Only admin can delete users");
            }
            else
            {
                _userRepository.DeleteUser(user);
                await _userRepository.Save();
            }
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            if (users.Count == 0 || users == null)
            {
                throw new UserNotFoundException();
            }
            if (_authService.GetAuthenticatedUserRole() != "Admin")
            {
                throw new UnauthorizedAccessException("Only admin can view users");
            }
            var result = _mapper.Map<List<UserDto>>(users);
            return result;
        }

        public async Task<UserDto> GetSingleUserByEmailAsync(string email)
        {
            if (email == null) throw new ArgumentNullException("Invalid argument passed");
            var user = await _userRepository.GetSingleUserAsync(x => x.Email == email);
            if (user == null) throw new UserNotFoundException();
            var result = _mapper.Map<UserDto>(user);
            return result;
        }

        public async Task UpdateUserAsync(UserDto model)
        {
            if (model == null) throw new ArgumentNullException("Invalid argument passed");
            if (model.Id != _authService.GetAuthenticatedUserId() && _authService.GetAuthenticatedUserRole() != "Admin")
            {
                throw new UnauthorizedAccessException("Cant update other users");
            }
            var result = _mapper.Map<IdentityUser>(model);
            result.NormalizedUserName = model.UserName.ToUpper();
            result.NormalizedEmail = model.Email.ToUpper();
            await _userRepository.UpdateUserAsync(result);
            await _userRepository.Save();
        }
    }
}
