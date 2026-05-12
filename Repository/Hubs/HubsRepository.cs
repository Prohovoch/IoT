using IoT.Models.Hubs;
using IoT.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IoT.Repository.Hubs
{
    public class HubsRepository : IHubsRepoository

    {
        private readonly ApplicationDbContext _dbcontext;

        public HubsRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<HubEntity?> GetByIdAsync(Guid id) =>
           await _dbcontext.Hubs.FirstOrDefaultAsync(h => h.Id == id);



        public async Task<HubEntity?> GetByIdRobDevAsync(Guid id) =>
            await _dbcontext.Hubs
            .Include(h => h.Devices )
            .Include(h=>h.Robots)
            .AsSplitQuery()
            .FirstOrDefaultAsync(h => h.Id == id);

        public async Task<IEnumerable<HubEntity>> GetAllAsync() =>
            await _dbcontext.Hubs.AsNoTracking().ToListAsync();


        public async Task CreateHubAsync(HubEntity hub)
        {
            // -> hack????
            await _dbcontext.Hubs.AddAsync(hub);


        }


        public async Task UpdateHubData(Guid id, HubEntity hub) =>
            await _dbcontext.Hubs.Where(h => h.Id == id).ExecuteUpdateAsync(h => h.SetProperty(h => h.HubIsActive, h => hub.HubIsActive)
            .SetProperty(h => h.HubAlias, h => hub.HubAlias));
            

        

        public async Task DeleteHubAsync(Guid id) =>
            await _dbcontext.Hubs.Where(h => h.Id == id).ExecuteDeleteAsync();

        public async Task SaveChangesAsync() =>
            await _dbcontext.SaveChangesAsync();
    }


}

