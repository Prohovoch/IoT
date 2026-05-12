using IoT.DTO.DeviceTelemetry;

namespace IoT.Service.DeviceTelemetry
{
    public interface IDeviceTelemService
    {
        Task<IEnumerable<DeviceTelemetryResp>> GetAllAsync(CancellationToken ct = default);
        Task<DeviceTelemetryResp> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<DeviceTelemetryResp> CreateAsync(DeviceTelemetryReq request, Guid deviceId, CancellationToken ct = default);
        Task UpdateAsync(Guid id, DeviceTelemUpdate update, CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);
    }
}
