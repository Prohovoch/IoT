using IoT.Models.Hubs;

namespace IoT.Repository.Hubs
{
    public interface IHubsRepository
    {
        Task<IEnumerable<HubEntity>> GetAllAsync(CancellationToken ct = default);
        Task<HubEntity?> GetByIdAsync(Guid id, CancellationToken ct = default);
        // Task<HubEntity?>GetByIdWithDevices(Guid id);
        // Task<HubEntity?> GetByIdWithRobots(Guid id);
        Task<HubEntity?> GetByIdRobDevAsync(Guid id, CancellationToken ct = default);
        Task DeleteHubAsync(Guid id, CancellationToken ct = default);
        public void CreateHub(HubEntity hub);
        Task UpdateHubData(Guid id, HubEntity hub, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
