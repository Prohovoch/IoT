using IoT.DTO.Devices;
using IoT.DTO.DeviceTelemetry;
using IoT.Models.Devices;
using IoT.Repository.Device;

namespace IoT.Service.Device
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<IEnumerable<DeviceResponse>> GetAllAsync(CancellationToken ct = default)
        {
            var devices = await _deviceRepository.GetAllAsync(ct);
            return devices.Select(d => new DeviceResponse
            {
                Id = d.Id,
                DevAlias = d.DevAlias,
                HubId = d.HubId
            });
        }

        public async Task<DeviceResponse> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            var device = await _deviceRepository.GetByIdAsync(id, ct);
            if (device is null)
                throw new KeyNotFoundException($"Device {id} not found");

            return new DeviceResponse
            {
                Id = device.Id,
                DevAlias = device.DevAlias,
                HubId = device.HubId
            };
        }

        public async Task<DeviceResponseExtra> GetByIdWithTelemAsync(Guid id, CancellationToken ct = default)
        {
            var device = await _deviceRepository.GetByIdTelemAsync(id, ct);
            if (device is null)
                throw new KeyNotFoundException($"Device {id} not found");

            return new DeviceResponseExtra
            {
                Id = device.Id,
                DevAlias = device.DevAlias,
                HubId = device.HubId,
                DevTelem = device.Telemetry is null ? null :
                    new List<DeviceTelemetryResp>
                    {
                        new DeviceTelemetryResp
                        {
                            Id = device.Telemetry.Id,
                            DeviceId = device.Telemetry.DeviceId,
                            DevType = device.Telemetry.DevType,
                            Temp = device.Telemetry.Tempreature,
                            Press = device.Telemetry.Pressure,
                            BattLevel = device.Telemetry.BatteryLevel,
                            Status = device.Telemetry.Status
                        }
                    }
            };
        }

        public async Task CreateDevice(DeviceRequest request, Guid hubId, CancellationToken ct = default)
        {
            var entity = new DeviceEntity
            {
                DevAlias = request.DevAlias,
                HubId = hubId
            };

            _deviceRepository.CreateDevice(entity);
            await _deviceRepository.SaveChangesAsync(ct);
        }

        public async Task UpdateDevice(Guid id, DeviceUpdate update, CancellationToken ct = default)
        {
            var device = await _deviceRepository.GetByIdAsync(id, ct);
            if (device is null)
                throw new KeyNotFoundException($"Device {id} not found");

            device.DevAlias = update.DevAlias;

            await _deviceRepository.UpdateDeviceData(id, device);
            
        }

        public async Task DeleteDevice(Guid id, CancellationToken ct = default)

        {
            var affected = await _deviceRepository.DeleteDeviceAsync(id, ct);
            if (affected == 0)
            {
                throw new KeyNotFoundException($"Device {id} not found");
            }

        }
    }
}

