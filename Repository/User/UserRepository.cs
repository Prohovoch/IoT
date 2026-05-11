using IoT.Models.Users;
using IoT.Persistence;
using IoT.Repository.User;
using Microsoft.EntityFrameworkCore;
namespace IoT.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {

            _context = context;

        }

        public async Task<UserEntity?> GetByIdAsync(Guid id) => 
            await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        
            

        public async Task<UserEntity?> GetByIdWithHubsAsync(Guid id) =>
            await _context.Users
            .Include(u => u.Hubs)
            .FirstOrDefaultAsync(u => u.Id == id);

        public async Task<IEnumerable<UserEntity>> GetAllAsync() =>
            await _context.Users.AsNoTracking().ToListAsync();


        public async Task CreateUserAsync(UserEntity user) =>
            await _context.Users.AddAsync(user);

        
        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is not null)
            {
                _context.Users.Remove(user);
            }
           
        }

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }

   
        
}
