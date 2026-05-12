using IoT.Models.Devices;

namespace IoT.Repository.Device
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<DeviceEntity>> GetAllAsync(CancellationToken ct = default);
        Task<DeviceEntity?> GetByIdAsync(Guid id, CancellationToken ct = default);
        // Task<HubEntity?>GetByIdWithDevices(Guid id);
        // Task<HubEntity?> GetByIdWithRobots(Guid id);
        Task<DeviceEntity?> GetByIdTelemAsync(Guid id, CancellationToken ct = default);
        Task DeleteDeviceAsync(Guid id, CancellationToken ct = default);
        public void CreateDevice(DeviceEntity device);
        Task UpdateDeviceData(Guid id, DeviceEntity device, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
