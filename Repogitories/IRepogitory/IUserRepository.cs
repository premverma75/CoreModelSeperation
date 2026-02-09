using CoreModelSeperation.Domain;

namespace CoreModelSeperation.Repogitories.IRepogitory
{
    public interface IUserRepository
    {
        Task<List<User?>> GetAllUsersAsync();
        Task<string?> GetUserNameAsync(Guid userId);

        Task<User?> AddUpdateUser(User user);
        Task<User?> GetUserDetails(Guid userId);       
        Task<bool?> DeleteUser(Guid userId);
       
    }
}