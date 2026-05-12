using IoT.Models.Users;
using IoT.Persistence;
using IoT.Repository.User;
using Microsoft.EntityFrameworkCore;
namespace IoT.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public UserRepository(ApplicationDbContext dbcontext)
        {

            _dbcontext = dbcontext;

        }

        public async Task<UserEntity?> GetByIdAsync(Guid id) => 
            await _dbcontext.Users.FirstOrDefaultAsync(u => u.Id == id);
        
            

        public async Task<UserEntity?> GetByIdWithHubsAsync(Guid id) =>
            await _dbcontext.Users
            .Include(u => u.Hubs)
            .FirstOrDefaultAsync(u => u.Id == id);

        public async Task<IEnumerable<UserEntity>> GetAllAsync() =>
            await _dbcontext.Users.AsNoTracking().ToListAsync();


        public async Task CreateUserAsync(UserEntity user)
        {   
            // -> hack????
            await _dbcontext.Users.AddAsync(user);
            
          
        }
            
             


        public async Task UpdateUserData(Guid id, UserEntity user) =>
            await _dbcontext.Users.Where(u => u.Id == id).ExecuteUpdateAsync(u => u.SetProperty(u => u.Name, u => user.Name)
            .SetProperty(u => u.Surname, u => user.Surname)
            .SetProperty(u => u.Age, u => user.Age));

        public async Task UpdatePartialUserData(Guid id, UserEntity user) =>
            await _dbcontext.Users.Where(u => u.Id == id).ExecuteUpdateAsync(u => u.SetProperty(u => u.Name, u => user.Name ?? u.Name)
            .SetProperty(u => u.Surname, u => user.Surname ?? u.Surname)
            .SetProperty(u => u.Age, u => user.Age ?? u.Age));

        public async Task DeleteUserAsync(Guid id) =>
            await _dbcontext.Users.Where(u => u.Id == id).ExecuteDeleteAsync();

        public async Task SaveChangesAsync() =>
            await _dbcontext.SaveChangesAsync();
    }

   
        
}
