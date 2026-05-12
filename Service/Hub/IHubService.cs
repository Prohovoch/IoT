using IoT.DTO.Hubs;


namespace IoT.Service.Hub
{
    public interface IHubService
    {
        Task<IEnumerable<HubsResponse>> GetAllAsync(CancellationToken ct = default);
        Task<HubsResponse?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<HubsResponseExtra?> GetByIdWithDevicesRobotsAsync(Guid id, CancellationToken ct = default);
        Task CreateHub(HubsRequest request, Guid userId, CancellationToken ct = default);
        Task UpdateHub(Guid id, HubUpdate update, CancellationToken ct = default);
        Task DeleteHub(Guid id, CancellationToken ct = default);
    }
}


