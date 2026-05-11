using IoT.DTO.RobotTelemetry;
namespace IoT.DTO.Robots
{
    public class RobotResponse
    {

        public Guid Id { get; init; }
        public Guid HubId { get; init; }
        public string? DevAlias { get; init;  }
        
    
    }

    public class RobotResponseExtra : RobotResponse {

        IEnumerable<RobotTelemResponse>? RobTelemetry { get; init; }

    }
}
