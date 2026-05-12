using IoT.DTO.Users;

namespace IoT.Service.User
{
    public interface IUserService
    {
        // Cotract for service
        Task<IEnumerable<UserResponse>> GetUsersResponseAsync();
        Task<UserResponse> GetUserById(Guid id);
        Task<UserResponse> GetUserWithHubs(Guid id);
        Task UserCreate(UserCreation creation);

        Task DeleteUser(Guid id);
        Task UpdateUser(UserUpdate user);
        Task UpdatePatch(Guid id, UserPatchUpdate patch);

    }
}
