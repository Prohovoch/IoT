using IoT.Models.Robots;

namespace IoT.Repository.Robots
{
    public interface IRobotRepository
    {
        Task<IEnumerable<RobotEntity>> GetAllAsync(CancellationToken ct = default);
        Task<RobotEntity?> GetByIdAsync(Guid id, CancellationToken ct = default);
        // Task<HubEntity?>GetByIdWithDevices(Guid id);
        // Task<HubEntity?> GetByIdWithRobots(Guid id);
        Task<RobotEntity?> GetByIdTelemAsync(Guid id, CancellationToken ct = default);
        Task DeleteRobotAsync(Guid id, CancellationToken ct = default);
        public void CreateRobot(RobotEntity robot);
        Task UpdateRobotData(Guid id, RobotEntity robot, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
