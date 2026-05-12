using IoT.Models.Devices;
using IoT.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IoT.Repository.Device
{
    public class DeviceRepository : IDeviceRepository

    {
        private readonly ApplicationDbContext _dbContext;
        public DeviceRepository(ApplicationDbContext dbcontext)
        {

            _dbContext = dbcontext;

        }

        public async Task<IEnumerable<DeviceEntity>> GetAllAsync(CancellationToken ct = default) =>
            await _dbContext.Devices.AsNoTracking().ToListAsync(ct);


        public async Task<DeviceEntity?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
            await _dbContext.Devices.FirstOrDefaultAsync(d => d.Id == id, ct);

       
        public async Task<DeviceEntity?> GetByIdTelemAsync(Guid id, CancellationToken ct = default) =>
            await _dbContext.Devices.Include(d => d.Telemetry ).FirstOrDefaultAsync(d => d.Id == id, ct);

        public async Task<int> DeleteDeviceAsync(Guid id, CancellationToken ct = default) =>
            await _dbContext.Devices.Where(d => d.Id == id).ExecuteDeleteAsync(ct);
        public void CreateDevice(DeviceEntity device)
        {
            _dbContext.Devices.Add(device);
        }

        public async Task UpdateDeviceData(Guid id, DeviceEntity device, CancellationToken ct = default) =>
            await _dbContext.Devices.Where(d => d.Id == id).ExecuteUpdateAsync(d => d.SetProperty(d => d.DevAlias, d => device.DevAlias), ct);
        public async Task SaveChangesAsync(CancellationToken ct = default) => await _dbContext.SaveChangesAsync(ct);


    }
}