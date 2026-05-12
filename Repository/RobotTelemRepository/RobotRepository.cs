using IoT.Models.RobotTelemetry;
using IoT.Persistence;
using IoT.Repository.Robots;
using Microsoft.EntityFrameworkCore;

namespace IoT.Repository.RobotTelemRepository
{
    public class RobotRepository : IRobotRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RobotRepository(ApplicationDbContext dbContext) 
        {

                _dbContext = dbContext;

        }


        public async Task<IEnumerable<RobTelemetryEntity>> GetAllAsync(CancellationToken ct = default) => 
            await _dbContext.RobotTelemetries.AsNoTracking().ToListAsync(ct);
        public async Task<RobTelemetryEntity?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
            await _dbContext.RobotTelemetries.Where(rt => rt.Id == id).FirstOrDefaultAsync(ct);
        public async Task <int> DeleteTelemAsync(Guid id, CancellationToken ct = default) =>
            await _dbContext.RobotTelemetries.Where(rt => rt.Id == id).ExecuteDeleteAsync(ct);

        public void CreateTelemetry(RobTelemetryEntity telemetry) => _dbContext.RobotTelemetries.Add(telemetry);

        public async Task UpdateTelemData(Guid id, RobTelemetryEntity telemetry, CancellationToken ct = default) =>
            await _dbContext.RobotTelemetries.Where(rt => rt.Id == id).ExecuteUpdateAsync(rt => rt.SetProperty(
                rt => rt.PositionX, rt => telemetry.PositionX)
            .SetProperty(rt => rt.PositionY, rt => telemetry.PositionY)
            .SetProperty(rt => rt.Status, rt => telemetry.Status)
            .SetProperty(rt => rt.Speed, rt => telemetry.Speed)
            .SetProperty(rt => rt.BatteryLevel, rt => telemetry.BatteryLevel), ct);

        public async Task SaveChangesAsync(CancellationToken ct = default) => await _dbContext.SaveChangesAsync(ct);

    }
}
