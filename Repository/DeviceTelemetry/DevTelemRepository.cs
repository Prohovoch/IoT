using IoT.Models.DeviceTelemetry;
using IoT.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IoT.Repository.DeviceTelemetry
{
    public class DevTelemRepository:IDeviceTelemetry

    {
        private readonly ApplicationDbContext _dbContext;

        public DevTelemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<DevTelemetryEntity>> GetAllAsync(CancellationToken ct = default) =>
            await _dbContext.DeviceTelemetries.AsNoTracking().ToListAsync(ct);
        public async Task<DevTelemetryEntity?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
            await _dbContext.DeviceTelemetries.FirstOrDefaultAsync(t => t.Id == id, ct);
        
        public async Task DeleteTelemAsync(Guid id, CancellationToken ct = default)=>
            await _dbContext.DeviceTelemetries.Where(t=>t.Id == id).ExecuteDeleteAsync(ct);
        public void CreateTelemetry(DevTelemetryEntity telemetry)
        {
            _dbContext.DeviceTelemetries.Add(telemetry);
        }

        public async Task UpdateTelemData(Guid id, DevTelemetryEntity telemetry, CancellationToken ct = default) =>
            await _dbContext.DeviceTelemetries.Where(t => t.Id == id).ExecuteUpdateAsync(t => t.SetProperty(t => t.Tempreature, t => telemetry.Tempreature)
            .SetProperty(t=>t.BatteryLevel, t=> telemetry.BatteryLevel)
            .SetProperty(t=>t.Pressure, t=> telemetry.Pressure)
            .SetProperty(t=>t.Status, t=> telemetry.Status), ct
            );

        public async Task SaveChangesAsync(CancellationToken ct = default) => await _dbContext.SaveChangesAsync(ct);
    }
}
