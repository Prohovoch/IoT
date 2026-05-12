using IoT.DTO.Users;

namespace IoT.Service.User
{
    public interface IUserService
    {
        // Cotract for service
        Task<IEnumerable<UserResponse>> GetUsersResponseAsync(CancellationToken ct = default);
        Task<UserResponse> GetUserById(Guid id, CancellationToken ct = default);
        Task<UserResponse> GetUserWithHubs(Guid id, CancellationToken ct = default);
        Task UserCreate(UserCreation creation, CancellationToken ct = default);

        Task DeleteUser(Guid id, CancellationToken ct = default);
        Task UpdateUser(UserUpdate user, CancellationToken ct = default);
        Task UpdatePatch(Guid id, UserPatchUpdate patch, CancellationToken ct = default);

    }
}
