using AutoMapper;
using MagazinAlimentar.DTOs;
using MagazinAlimentar.Helpers.JwtUtils;
using MagazinAlimentar.Models;
using MagazinAlimentar.Repositories.UserRepository;
using BCryptNet = BCrypt.Net.BCrypt;

namespace MagazinAlimentar.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        public IMapper _mapper;
        public IJwtUtils _jwtUtils;

        public UserService(IUserRepository userRepository, IMapper mapper, IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllAsync();
        }

        public UserResponseDTO Authenticate(UserRequestDTO model)
        {
            var user = _userRepository.FindByUsername(model.UserName);
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                return null;
            }

            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            return new UserResponseDTO(user, jwtToken);
        }

        public User GetById(Guid id)
        {
            return _userRepository.FindById(id);
        }

        public async Task Create(User newUser)
        {
            await _userRepository.CreateAsync(newUser);
            await _userRepository.SaveAsync();
        }

        public async Task Update(User newUser)
        {
            _userRepository.Update(newUser);
            await _userRepository.SaveAsync();
        }
        public async Task Delete(User userDelete)
        {
            _userRepository.Delete(userDelete);
            await _userRepository.SaveAsync();
        }
    }
}
