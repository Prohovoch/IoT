using IoT.Models.Hubs;
using IoT.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IoT.Repository.Hubs
{
    public class HubsRepository : IHubsRepository

    {
        private readonly ApplicationDbContext _dbcontext;

        public HubsRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<HubEntity?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
           await _dbcontext.Hubs.FirstOrDefaultAsync(h => h.Id == id, ct);



        public async Task<HubEntity?> GetByIdRobDevAsync(Guid id, CancellationToken ct = default) =>
            await _dbcontext.Hubs
            .Include(h => h.Devices)
            .Include(h=>h.Robots)
            .AsSplitQuery()
            .FirstOrDefaultAsync(h => h.Id == id, ct);

        public async Task<IEnumerable<HubEntity>> GetAllAsync(CancellationToken ct = default) =>
            await _dbcontext.Hubs.AsNoTracking().ToListAsync(ct);


        public void CreateHub(HubEntity hub)
        {
            // -> in memory request
             _dbcontext.Hubs.Add(hub);


        }


        public async Task UpdateHubData(Guid id, HubEntity hub, CancellationToken ct = default) =>
            await _dbcontext.Hubs.Where(h => h.Id == id).ExecuteUpdateAsync(h => h.SetProperty(h => h.HubIsActive, h => hub.HubIsActive)
            .SetProperty(h => h.HubAlias, h => hub.HubAlias), ct);
            

        

        public async Task <int> DeleteHubAsync(Guid id, CancellationToken ct = default) =>
            await _dbcontext.Hubs.Where(h => h.Id == id).ExecuteDeleteAsync(ct);

        public async Task SaveChangesAsync(CancellationToken ct = default) =>
            await _dbcontext.SaveChangesAsync(ct);
    }


}

