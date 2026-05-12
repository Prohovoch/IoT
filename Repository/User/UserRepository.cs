using IoT.Models.Users;
using IoT.Persistence;
using IoT.Repository.User;
using Microsoft.EntityFrameworkCore;
namespace IoT.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbcontext)
        {

            _dbContext = dbcontext;

        }

        public async Task<UserEntity?> GetByIdAsync(Guid id, CancellationToken ct = default) => 
            await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);



        public async Task<UserEntity?> GetByIdWithHubsAsync(Guid id, CancellationToken ct = default) =>
            await _dbContext.Users
            .Include(u => u.Hubs)
            .FirstOrDefaultAsync(u => u.Id == id, ct);
        public async Task<IEnumerable<UserEntity>> GetAllAsync(CancellationToken ct = default) =>
            await _dbContext.Users.AsNoTracking().ToListAsync();


        public void CreateUser(UserEntity user)
        {   
            // -> in memory, no io
            _dbContext.Users.Add(user);
            
          
        }
            
             


        public async Task UpdateUserData(Guid id, UserEntity user, CancellationToken ct = default) =>
            await _dbContext.Users.Where(u => u.Id == id).ExecuteUpdateAsync(u => u.SetProperty(u => u.Name, u => user.Name)
            .SetProperty(u => u.Surname, u => user.Surname)
            .SetProperty(u => u.Age, u => user.Age), ct);

       
        public async Task <int> DeleteUserAsync(Guid id, CancellationToken ct = default) =>
            await _dbContext.Users.Where(u => u.Id == id).ExecuteDeleteAsync(ct);

        public async Task SaveChangesAsync(CancellationToken ct = default) =>
            await _dbContext.SaveChangesAsync(ct);
    }

   
        
}
