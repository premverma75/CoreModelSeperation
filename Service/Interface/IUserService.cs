using CoreModelSeperation.DataTransferObjects;
using CoreModelSeperation.Domain;

namespace CoreModelSeperation.Service.Interface
{
    public interface IUserService
    {
        Task<User?> GetUserDetails(Guid userId);
        Task<bool?> DeleteUser(Guid userId);
        Task<List<User?>> GetAllUsersAsync();
        Task<string?> GetUserNameAsync(Guid userId);

        Task<User?> AddUpdateUser(CreateUserRequestDto createUserRequestDto);
    }
}