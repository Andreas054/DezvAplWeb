using AutoMapper;
using MagazinAlimentar.DTOs;
using MagazinAlimentar.Repositories.UserRepository;

namespace MagazinAlimentar.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        public IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            var userList = await _userRepository.GetAllAsync();

            return _mapper.Map<List<UserDTO>>(userList);
        }

        public bool Create(UserDTO userDTO)
        {
            _userRepository.CreateDTO(userDTO);
            return true;
        }

        public UserDTO GetUserByName(string name)
        {
            var user = _userRepository.FindByName(name);
            return _mapper.Map<UserDTO>(user);
        }
    }
}
