using IoT.Models.Robots;
using IoT.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IoT.Repository.Robots
{
    public class RobotRepository : IRobotRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RobotRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<IEnumerable<RobotEntity>> GetAllAsync(CancellationToken ct = default) =>
           await _dbContext.Robots.AsNoTracking().ToListAsync(ct);


        public async Task<RobotEntity?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
            await _dbContext.Robots.FirstOrDefaultAsync(r => r.Id == id, ct);


        public async Task<RobotEntity?> GetByIdTelemAsync(Guid id, CancellationToken ct = default) =>
            await _dbContext.Robots.Include(r => r.Telemetry).FirstOrDefaultAsync(r => r.Id == id, ct);

        public async Task <int> DeleteRobotAsync(Guid id, CancellationToken ct = default) =>
            await _dbContext.Robots.Where(r => r.Id == id).ExecuteDeleteAsync(ct);
        public void CreateRobot(RobotEntity robot)
        {
            _dbContext.Robots.Add(robot);
        }

        public async Task UpdateRobotData(Guid id, RobotEntity robot, CancellationToken ct = default) =>
            await _dbContext.Devices.Where(r => r.Id == id).ExecuteUpdateAsync(r => r.SetProperty(r => r.DevAlias, r => robot.DevAlias), ct);
        public async Task SaveChangesAsync(CancellationToken ct = default) => await _dbContext.SaveChangesAsync(ct);


    }
}
