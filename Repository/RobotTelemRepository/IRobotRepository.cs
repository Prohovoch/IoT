using IoT.Models.RobotTelemetry;

namespace IoT.Repository.RobotTelemRepository
{
    public interface IRobotTelemRepository
    {
        Task<IEnumerable<RobTelemetryEntity>> GetAllAsync(CancellationToken ct = default);
        Task<RobTelemetryEntity?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task <int> DeleteTelemAsync(Guid id, CancellationToken ct = default);
        public void CreateTelemetry(RobTelemetryEntity telemetry);
        Task UpdateTelemData(Guid id, RobTelemetryEntity telemetry, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
