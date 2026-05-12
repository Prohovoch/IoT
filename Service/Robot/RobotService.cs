using IoT.DTO.Robots;
using IoT.DTO.RobotTelemetry;
using IoT.Models.Robots;
using IoT.Repository.Robots;
namespace IoT.Service.Robot
{
    public class RobotService
    {
        private readonly IRobotRepository _robotRepository;

        public RobotService(IRobotRepository robotRepository)
        {
            _robotRepository = robotRepository;
        }

        public async Task<IEnumerable<RobotResponse>> GetAllAsync(CancellationToken ct)
        {
            var robots = await _robotRepository.GetAllAsync(ct);
            return robots.Select(r => new RobotResponse
            {
                Id = r.Id,
                DevAlias = r.DevAlias,
                HubId = r.HubId
            });
        }

        public async Task<RobotResponse> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var robot = await _robotRepository.GetByIdAsync(id, ct);
            if (robot is null)
                throw new KeyNotFoundException($"Robot {id} not found");

            return new RobotResponse
            {
                Id = robot.Id,
                DevAlias = robot.DevAlias,
                HubId = robot.HubId
            };
        }

        public async Task<RobotResponseExtra> GetByIdWithTelemAsync(Guid id, CancellationToken ct)
        {
            var robot = await _robotRepository.GetByIdTelemAsync(id, ct);
            if (robot is null)
                throw new KeyNotFoundException($"Robot {id} not found");

            return new RobotResponseExtra
            {
                Id = robot.Id,
                DevAlias = robot.DevAlias,
                HubId = robot.HubId,
                RobTelemetry = robot.Telemetry is null ? null :
                    new List<RobotTelemResponse>
                    {
                        new RobotTelemResponse
                        {
                            Id = robot.Telemetry.Id,
                            RobotId = robot.Telemetry.RobotId,
                            RobotType = robot.Telemetry.DevType,
                            Status = robot.Telemetry.Status,
                            PosX = robot.Telemetry.PositionX,
                            PosY = robot.Telemetry.PositionY,
                            Battery = robot.Telemetry.BatteryLevel,
                            Speed = robot.Telemetry.Speed
                        }
                    }
            };
        }

        public async Task CreateRobot(RobotsRequest request, Guid hubId, CancellationToken ct)
        {
            var entity = new RobotEntity
            {
                DevAlias = request.DevAlias,
                HubId = hubId
            };

            _robotRepository.CreateRobot(entity);
            await _robotRepository.SaveChangesAsync(ct);
        }

        public async Task UpdateRobot(Guid id, RobotUpdate update, CancellationToken ct)
        {
            var robot = await _robotRepository.GetByIdAsync(id);
            if (robot is null)
                throw new KeyNotFoundException($"Robot {id} not found");

            robot.DevAlias = update.DevAlias;

            await _robotRepository.UpdateRobotData(id, robot, ct);
            
        }

        public async Task DeleteRobot(Guid id)
        {

            var affected = await _robotRepository.DeleteRobotAsync(id);
            if (affected == 0)
            {
                throw new KeyNotFoundException($"Robot {id} not found");
            }

        }
    }
}
