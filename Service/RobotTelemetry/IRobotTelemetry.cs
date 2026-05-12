using IoT.DTO.RobotTelemetry;

namespace IoT.Service.RobotTelemetry
{
    public interface IRobotTelemetry
    {
        Task<IEnumerable<RobotTelemResponse>> GetAllAsync(CancellationToken ct = default);
        Task<RobotTelemResponse> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<RobotTelemResponse> CreateAsync(RobotTelemetryReq request, Guid robotId, CancellationToken ct = default);
        Task UpdateAsync(Guid id, RobotTelemetryUp update, CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);
    }
}
