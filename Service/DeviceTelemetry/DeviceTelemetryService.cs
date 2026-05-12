using IoT.DTO.DeviceTelemetry;
using IoT.Models.DeviceTelemetry;
using IoT.Repository.DeviceTelemetry;


namespace IoT.Service.DeviceTelemetry
{
    public class DeviceTelemetryService : IDeviceTelemService
    {
       
    
        private readonly IDeviceTelemetry _telemRepository;

        public DeviceTelemetryService(IDeviceTelemetry telemRepository)
        {
            _telemRepository = telemRepository;
        }

        public async Task<IEnumerable<DeviceTelemetryResp>> GetAllAsync(CancellationToken ct = default)
        {
            var telemetries = await _telemRepository.GetAllAsync(ct);
            return telemetries.Select(t => new DeviceTelemetryResp
            {
                Id = t.Id,
                DeviceId = t.DeviceId,
                DevType = t.DevType,
                Temp = t.Tempreature,
                Press = t.Pressure,
                BattLevel = t.BatteryLevel,
                Status = t.Status
            });
        }

        public async Task<DeviceTelemetryResp> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            var telemetry = await _telemRepository.GetByIdAsync(id, ct);
            if (telemetry is null)
                throw new KeyNotFoundException($"Telemetry {id} not found");

            return new DeviceTelemetryResp
            {
                Id = telemetry.Id,
                DeviceId = telemetry.DeviceId,
                DevType = telemetry.DevType,
                Temp = telemetry.Tempreature,
                Press = telemetry.Pressure,
                BattLevel = telemetry.BatteryLevel,
                Status = telemetry.Status
            };
        }

        public async Task<DeviceTelemetryResp> CreateAsync(
            DeviceTelemetryReq request,
            Guid deviceId,
            CancellationToken ct = default)
        {
            var entity = new DevTelemetryEntity
            {
                DeviceId = deviceId,
                DevType = request.DevType,
                Tempreature = request.Temp,
                Pressure = request.Press,
                BatteryLevel = request.BattLevel,
                Status = request.Status
            };

            _telemRepository.CreateTelemetry(entity);
            await _telemRepository.SaveChangesAsync(ct);

            return new DeviceTelemetryResp
            {
                Id = entity.Id,
                DeviceId = entity.DeviceId,
                DevType = entity.DevType,
                Temp = entity.Tempreature,
                Press = entity.Pressure,
                BattLevel = entity.BatteryLevel,
                Status = entity.Status
            };
        }

        public async Task UpdateAsync(Guid id, DeviceTelemUpdate update, CancellationToken ct = default)
        {
            var telemetry = await _telemRepository.GetByIdAsync(id, ct);
            if (telemetry is null)
                throw new KeyNotFoundException($"Telemetry {id} not found");

            if (update.Temp is not null)
                telemetry.Tempreature = update.Temp;

            if (update.Press is not null)
                telemetry.Pressure = update.Press;

            if (update.BattLevel is not null)
                telemetry.BatteryLevel = update.BattLevel;

            if (update.Status is not null)
                telemetry.Status = update.Status;

            await _telemRepository.UpdateTelemData(id, telemetry, ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
           var affected =  await _telemRepository.DeleteTelemAsync(id, ct);
           if (affected == 0) {
                throw new KeyNotFoundException($"Telemetry {id} not found");
            }
        }
    }
}
