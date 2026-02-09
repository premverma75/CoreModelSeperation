using CoreModelSeperation.Data;
using CoreModelSeperation.Domain;
using CoreModelSeperation.Repogitories.IRepogitory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace CoreModelSeperation.Repogitories.Repogitory
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IDistributedCache _distributedCache;

        public UserRepository(AppDbContext appDbContext, IDistributedCache distributedCache)
        {
            this._appDbContext = appDbContext;
            this._distributedCache = distributedCache;
        }

        public Task<User?> AddUpdateUser(User user)
        {
            if (user.Id == Guid.Empty || !_appDbContext.Users.Any(u => u.Id == user.Id))
            {
                user.Id = Guid.NewGuid();

                _appDbContext.Users.Add(user);
            }
            else
            {
                _appDbContext.Users.Update(user);
            }
            _appDbContext.SaveChanges();
            return Task.FromResult<User?>(user);
        }

        public Task<bool?> DeleteUser(Guid userId)
        {
            var user = _appDbContext.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                return Task.FromResult<bool?>(false);

            _appDbContext.Users.Remove(user);
            _appDbContext.SaveChanges();
            return Task.FromResult<bool?>(true);
        }

        public async Task<List<User?>> GetAllUsersAsync()
        {
            var list = await _appDbContext.Users.AsNoTracking().ToListAsync();
            var result = list.Select(u => (User?)u).ToList();
            return result;
        }

        public async Task<User?> GetUserDetails(Guid userId)
        {
            var user = await _appDbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
            return (User?)user;
        }

        public async Task<string?> GetUserNameAsync(Guid userId)
        {
            var cacheKey = $"username_{userId}";
            var cachedResult = _distributedCache.GetString(cacheKey);
            if (cachedResult != null)
                return cachedResult;

            var name = await _appDbContext.Users.Where(u => u.Id == userId)
                 .AsNoTracking().Select(u => u.Name)
                 .FirstOrDefaultAsync();
            return (string?)name;
        }
    }
}