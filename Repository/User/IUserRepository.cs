using IoT.Models.Users;

namespace IoT.Repository.User
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetAllAsync();
        Task<UserEntity?> GetByIdAsync(Guid id);
        Task DeleteUserAsync(Guid id);
        Task CreateUserAsync(UserEntity user);
        Task UpdateUserData(Guid id, UserEntity user);
        Task UpdatePartialUserData(Guid id, UserEntity user);
        Task SaveChangesAsync();
    }
}
