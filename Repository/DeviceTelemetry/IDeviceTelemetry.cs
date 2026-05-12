using IoT.Models.DeviceTelemetry;

namespace IoT.Repository.DeviceTelemetry
{
    public interface IDeviceTelemetry
    {
        Task<IEnumerable<DevTelemetryEntity>> GetAllAsync(CancellationToken ct = default);
        Task<DevTelemetryEntity?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task DeleteTelemAsync(Guid id, CancellationToken ct = default);
        public void CreateTelemetry(DevTelemetryEntity telemetry);
        Task UpdateTelemData(Guid id, DevTelemetryEntity telemetry, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
