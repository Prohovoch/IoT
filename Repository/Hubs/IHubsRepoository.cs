using IoT.Models.Hubs;

namespace IoT.Repository.Hubs
{
    public interface IHubsRepoository
    {
        Task<IEnumerable<HubEntity>> GetAllAsync();
        Task<HubEntity?> GetByIdAsync(Guid id);
        // Task<HubEntity?>GetByIdWithDevices(Guid id);
        // Task<HubEntity?> GetByIdWithRobots(Guid id);
        Task<HubEntity?> GetByIdRobDevAsync(Guid id);
        Task DeleteHubAsync(Guid id);
        Task CreateHubAsync(HubEntity hub);
        Task UpdateHubData(Guid id, HubEntity hub);
        Task SaveChangesAsync();
    }
}
