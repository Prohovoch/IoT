using IoT.DTO.Robots;

namespace IoT.Service.Robot
{
    public interface IRobotService
    {
        Task<IEnumerable<RobotResponse>> GetAllAsync(CancellationToken ct = default);
        Task<RobotResponse> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<RobotResponseExtra> GetByIdWithTelemAsync(Guid id, CancellationToken ct = default);
        Task CreateRobot(RobotsRequest request, Guid hubId, CancellationToken ct = default);
        Task UpdateRobot(Guid id, RobotUpdate update, CancellationToken ct = default);
        Task DeleteRobot(Guid id, CancellationToken ct = default);
    }
}
