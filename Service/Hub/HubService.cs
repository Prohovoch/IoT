using IoT.DTO.Devices;
using IoT.DTO.Hubs;
using IoT.DTO.Robots;
using IoT.Models.Hubs;
using IoT.Repository.Hubs;

namespace IoT.Service.Hub
{
    public class HubService : IHubService
    {
        
    
        private readonly IHubsRepository _hubRepository;

        public HubService(IHubsRepository hubRepo)
        {
            _hubRepository = hubRepo;
        }

        public async Task<IEnumerable<HubsResponse>> GetAllAsync()
        {
            var hubs = await _hubRepository.GetAllAsync();
            return hubs.Select(h => new HubsResponse
            {
                Id = h.Id,
                HubAlias = h.HubAlias,
                IsActive = h.HubIsActive,
                UserId = h.UserId
            });
        }

        public async Task<HubsResponse> GetByIdAsync(Guid id)
        {
            var hub = await _hubRepository.GetByIdAsync(id);
            if (hub is null)
                throw new KeyNotFoundException($"Hub {id} not found");

            return new HubsResponse
            {
                Id = hub.Id,
                HubAlias = hub.HubAlias,
                IsActive = hub.HubIsActive,
                UserId = hub.UserId
            };
        }

        public async Task<HubsResponseExtra> GetByIdWithDevicesRobotsAsync(Guid id)
        {
            var hub = await _hubRepository.GetByIdRobDevAsync(id);
            if (hub is null)
                throw new KeyNotFoundException($"Hub {id} not found");

            return new HubsResponseExtra
            {
                Id = hub.Id,
                HubAlias = hub.HubAlias,
                IsActive = hub.HubIsActive,
                UserId = hub.UserId,
                Devices = hub.Devices?.Select(d => new DeviceResponse
                {
                    Id = d.Id,
                    DevAlias = d.DevAlias,
                    HubId = d.HubId
                }),
                Robots = hub.Robots?.Select(r => new RobotResponse
                {
                    Id = r.Id,
                    DevAlias = r.DevAlias,
                    HubId = r.HubId
                })
            };
        }

        public async Task CreateHub(HubsRequest request, Guid userId)
        {
            var entity = new HubEntity
            {
                HubAlias = request.HubAlias,
                HubIsActive = request.IsActive ?? false,
                UserId = userId
            };

            _hubRepository.CreateHub(entity);
            await _hubRepository.SaveChangesAsync();
        }

        public async Task UpdateHub(Guid id, HubUpdate update)
        {
            var hub = await _hubRepository.GetByIdAsync(id);
            if (hub is null)
                throw new KeyNotFoundException($"Hub {id} not found");

            if (update.HubAlias is not null)
                hub.HubAlias = update.HubAlias;

            if (update.isActive is not null)
                hub.HubIsActive = update.isActive.Value;

            await _hubRepository.UpdateHubData(id, hub);
         
        }

        public async Task DeleteHub(Guid id)
        {
            
            var affected = await _hubRepository.DeleteHubAsync(id);
            if (affected == 0)
            {
                throw new KeyNotFoundException(($"Hub {id} not found"));
            }
            
        }
    }
}
 