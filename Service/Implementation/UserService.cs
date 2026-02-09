using CoreModelSeperation.Data;
using CoreModelSeperation.DataTransferObjects;
using CoreModelSeperation.Domain;
using CoreModelSeperation.Repogitories.IRepogitory;
using CoreModelSeperation.Service.Interface;
using Mapster;

namespace CoreModelSeperation.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User?> AddUpdateUser(CreateUserRequestDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var user = dto.Adapt<User>();
            user.Name=dto.FirstName+" "+dto.LastName;
            user.Id = Guid.NewGuid();
            user.PasswordHash =BCrypt.Net.BCrypt.HashPassword( dto.Password);   // hash later
            return _userRepository.AddUpdateUser(user);
        }

        public Task<bool?> DeleteUser(Guid userId)
        {
            return _userRepository.DeleteUser(userId);
        }

        public Task<List<User?>> GetAllUsersAsync()
        {
            return _userRepository.GetAllUsersAsync();
        }

        public Task<User?> GetUserDetails(Guid userId)
        {
            return _userRepository.GetUserDetails(userId);
        }

        public Task<string?> GetUserNameAsync(Guid userId)
        {
            return _userRepository.GetUserNameAsync(userId);
        }
    }
}