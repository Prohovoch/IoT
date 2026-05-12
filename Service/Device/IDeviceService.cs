using IoT.DTO.Devices;

namespace IoT.Service.Device
{
    public interface IDeviceService
    {
        Task<IEnumerable<DeviceResponse>> GetAllAsync(CancellationToken ct = default);
        Task<DeviceResponse> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<DeviceResponseExtra> GetByIdWithTelemAsync(Guid id, CancellationToken ct = default);
        Task CreateDevice(DeviceRequest request, Guid hubId, CancellationToken ct );
        Task UpdateDevice(Guid id, DeviceUpdate update, CancellationToken ct = default);
        Task DeleteDevice(Guid id, CancellationToken ct = default);

        
    }
}
