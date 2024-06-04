using AutoMapper;
using Forum.Application.Identity;
using Forum.Application.Interfaces;
using Forum.Core.Common.Exceptions;
using Forum.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
namespace Forum.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public const string _adminRole = "admin";
        public const string _customerRole = "customer";

        public AuthService(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IJwtGenerator jwtGenerator, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtGenerator = jwtGenerator;
            _httpContextAccessor = httpContextAccessor;
            _mapper = MappingInitializer.Initialize();
        }
        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email!.ToLower() == loginRequestDto.Email.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(user!, loginRequestDto.Password);
            if (user is null || !isValid)
            {
                return new LoginResponseDTO()
                {
                    Token = string.Empty,
                    User = null!
                };
            }
            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtGenerator.GenerateJwtToken(user, roles);

            UserDto userDto = new()
            {
                Id = user.Id,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber!
            };

            LoginResponseDTO result = new()
            {
                User = userDto,
                Token = token
            };

            return result;
        }

        public async Task Register(RegistrationRequestDTO registrationRequestDto)
        {
            var user = _mapper.Map<IdentityUser>(registrationRequestDto);            
            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
                if (result.Succeeded)
                {
                    var userToReturn = await _context.Users.FirstOrDefaultAsync(x => x.Email!.ToLower() == registrationRequestDto.Email.ToLower());
                    if (userToReturn != null)
                    {
                        if (!await _roleManager.RoleExistsAsync(_customerRole))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(_customerRole));
                        }
                        await _userManager.AddToRoleAsync(userToReturn, _customerRole);

                        var userDto = _mapper.Map<UserDto>(userToReturn);
                        
                    }
                }
                else
                {
                    throw new RegistrationFailureException(result.Errors.FirstOrDefault()!.Description);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task RegisterAdmin(RegistrationRequestDTO registrationRequestDto)
        {
            IdentityUser user = new()
            {
                UserName = registrationRequestDto.Email,
                NormalizedUserName = registrationRequestDto.Email.ToUpper(),
                Email = registrationRequestDto.Email,
                NormalizedEmail = registrationRequestDto.Email.ToUpper(),
                PhoneNumber = registrationRequestDto.PhoneNumber
            };
            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
                if (result.Succeeded)
                {
                    var userToReturn = await _context.Users.FirstOrDefaultAsync(x => x.Email!.ToLower() == registrationRequestDto.Email.ToLower());
                    if (userToReturn != null)
                    {
                        if (!await _roleManager.RoleExistsAsync(_adminRole))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(_adminRole));
                        }
                        await _userManager.AddToRoleAsync(userToReturn, _adminRole);
                        UserDto userDto = new()
                        {
                            Email = userToReturn.Email!,
                            Id = userToReturn.Id,
                            PhoneNumber = userToReturn.PhoneNumber!
                        };
                    }
                }
                else
                {
                    throw new RegistrationFailureException(result.Errors.FirstOrDefault()!.Description);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetAuthenticatedUserId()
        {
            if (_httpContextAccessor.HttpContext.User.Identity!.IsAuthenticated)
            {
                return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            }
            else
            {
                throw new UnauthorizedAccessException("Can't get credentials of unauthorized user");
            }
        }
        public string GetAuthenticatedUserRole()
        {
            if (_httpContextAccessor.HttpContext.User.Identity!.IsAuthenticated)
            {
                return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role)!;
            }
            else
            {
                throw new UnauthorizedAccessException("Can't get credentials of unauthorized user");
            }
        }
    }
}
