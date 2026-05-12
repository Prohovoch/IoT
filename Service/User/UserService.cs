using IoT.DTO.Hubs;
using IoT.DTO.Users;
using IoT.Models.Users;
using IoT.Repository.User;

namespace IoT.Service.User
{
    public class UserService : IUserService

    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }


            // GET ALL
            public async Task<IEnumerable<UserResponse>> GetUsersResponseAsync()
            {
                var users = await _userRepository.GetAllAsync();

                return users.Select(u => new UserResponse
                {
                    Id = u.Id,
                    Name = u.Name,
                    Surname = u.Surname,
                    Age = u.Age
                });
            }

            // GET BY ID
            public async Task<UserResponse> GetUserById(Guid id)
            {
                var user = await _userRepository.GetByIdAsync(id);

                if (user is null)
                    throw new KeyNotFoundException($"User {id} not found");

                return new UserResponse
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Age = user.Age
                };
            }

            // GET WITH HUBS
            public async Task<UserResponse> GetUserWithHubs(Guid id)
            {
                var user = await _userRepository.GetByIdWithHubsAsync(id);

                if (user is null)
                    throw new KeyNotFoundException($"User {id} not found");

                return new UserResponseHubs
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Age = user.Age,
                    Hubs = user.Hubs?.Select(h => new HubsResponse
                    {
                        Id = h.Id,
                        HubAlias = h.HubAlias,
                        IsActive = h.HubIsActive
                    })
                };
            }

            // CREATE
            public async Task UserCreate(UserCreation creation)
            {
                var entity = new UserEntity
                {
                    Name = creation.Name,
                    Surname = creation.Surname,
                    Age = creation.Age
                };

                _userRepository.CreateUser(entity);
                await _userRepository.SaveChangesAsync();
            }

            // DELETE
            public async Task DeleteUser(Guid id)
            {
                var affected = await _userRepository.DeleteUserAsync(id);

                if (affected == 0)
                    throw new KeyNotFoundException($"User {id} not found");
            }

            // PUT — полное обновление
            public async Task UpdateUser(UserUpdate dto)
            {
                var user = await _userRepository.GetByIdAsync(dto.Id);

                if (user is null)
                    throw new KeyNotFoundException($"User {dto.Id} not found");

                user.Name = dto.Name;
                user.Surname = dto.Surname;
                user.Age = dto.Age;

                await _userRepository.UpdateUserData(dto.Id, user);
                
            }

            // PATCH — частичное обновление
            public async Task UpdatePatch(Guid id, UserPatchUpdate patch)
            {
                var user = await _userRepository.GetByIdAsync(id);

                if (user is null)
                    throw new KeyNotFoundException($"User {id} not found");

                if (patch.Name is not null)
                    user.Name = patch.Name;

                if (patch.Surname is not null)
                    user.Surname = patch.Surname;

                if (patch.Age is not null)
                    user.Age = patch.Age;

                await _userRepository.UpdateUserData(id, user);
                
            }
        }
    }



