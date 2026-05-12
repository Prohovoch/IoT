using IoT.Models.Users;

namespace IoT.Repository.User
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetAllAsync(CancellationToken ct = default);
        Task<UserEntity?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<UserEntity?> GetByIdWithHubsAsync(Guid id, CancellationToken ct = default);
        Task DeleteUserAsync(Guid id, CancellationToken ct = default);
        public void CreateUser(UserEntity user);
        Task UpdateUserData(Guid id, UserEntity user, CancellationToken ct = default);
        Task UpdatePartialUserData(Guid id, UserEntity user, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
