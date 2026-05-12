using IoT.DTO.Hubs;


namespace IoT.Service.Hub
{
    public interface IHubService
    {
        Task<IEnumerable<HubsResponse>> GetAllAsync();
        Task<HubsResponse> GetByIdAsync(Guid id);
        Task<HubsResponseExtra> GetByIdWithDevicesRobotsAsync(Guid id);
        Task CreateHub(HubsRequest request, Guid userId);
        Task UpdateHub(Guid id, HubUpdate update);
        Task DeleteHub(Guid id);
    }
}


