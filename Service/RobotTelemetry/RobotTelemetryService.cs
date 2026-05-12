using IoT.DTO.RobotTelemetry;
using IoT.Models.RobotTelemetry;
using IoT.Repository.RobotTelemRepository;


namespace IoT.Service.RobotTelemetry
{
        public class RobotTelemetryService : IRobotTelemetry
        {
            private readonly IRobotRepository _robTelemRepository;

            public RobotTelemetryService(IRobotRepository robTelemRepository)
            {
                _robTelemRepository = robTelemRepository;
            }

            public async Task<IEnumerable<RobotTelemResponse>> GetAllAsync(CancellationToken ct = default)
            {
                var telemetries = await _robTelemRepository.GetAllAsync(ct);
                return telemetries.Select(t => new RobotTelemResponse
                {
                    Id = t.Id,
                    RobotId = t.RobotId,
                    RobotType = t.DevType,
                    Status = t.Status,
                    PosX = t.PositionX,
                    PosY = t.PositionY,
                    Battery = t.BatteryLevel,
                    Speed = t.Speed
                });
            }

            public async Task<RobotTelemResponse> GetByIdAsync(Guid id, CancellationToken ct = default)
            {
                var telemetry = await _robTelemRepository.GetByIdAsync(id, ct);
                if (telemetry is null)
                    throw new KeyNotFoundException($"Telemetry {id} not found");

                return new RobotTelemResponse
                {
                    Id = telemetry.Id,
                    RobotId = telemetry.RobotId,
                    RobotType = telemetry.DevType,
                    Status = telemetry.Status,
                    PosX = telemetry.PositionX,
                    PosY = telemetry.PositionY,
                    Battery = telemetry.BatteryLevel,
                    Speed = telemetry.Speed
                };
            }

            public async Task<RobotTelemResponse> CreateAsync(
                RobotTelemetryReq request,
                Guid robotId,
                CancellationToken ct = default)
            {
                var entity = new RobTelemetryEntity
                {
                    RobotId = robotId,
                    DevType = request.RobotType,
                    Status = request.Status,
                    PositionX = request.PosX,
                    PositionY = request.PosY,
                    BatteryLevel = request.Battery,
                    Speed = request.Speed
                };

                _robTelemRepository.CreateTelemetry(entity);
                await _robTelemRepository.SaveChangesAsync(ct);

                return new RobotTelemResponse
                {
                    Id = entity.Id,
                    RobotId = entity.RobotId,
                    RobotType = entity.DevType,
                    Status = entity.Status,
                    PosX = entity.PositionX,
                    PosY = entity.PositionY,
                    Battery = entity.BatteryLevel,
                    Speed = entity.Speed
                };
            }

            public async Task UpdateAsync(Guid id, RobotTelemetryUp update, CancellationToken ct = default)
            {
                var telemetry = await _robTelemRepository.GetByIdAsync(id, ct);
                if (telemetry is null)
                    throw new KeyNotFoundException($"Telemetry {id} not found");

                if (update.RobotType is not null)
                    telemetry.DevType = update.RobotType;

                if (update.Status is not null)
                    telemetry.Status = update.Status;

                if (update.PosX is not null)
                    telemetry.PositionX = update.PosX;

                if (update.PosY is not null)
                    telemetry.PositionY = update.PosY;

                if (update.Battery is not null)
                    telemetry.BatteryLevel = update.Battery;

                if (update.Speed is not null)
                    telemetry.Speed = update.Speed;

                await _robTelemRepository.UpdateTelemData(id, telemetry, ct);
            }
            public async Task DeleteAsync(Guid id, CancellationToken ct = default)
            {
                var affected = await _robTelemRepository.DeleteTelemAsync(id, ct);
                if (affected == 0)
                {
                    throw new KeyNotFoundException($"Telemetry {id} not found");
                }
            }
        }
    }


