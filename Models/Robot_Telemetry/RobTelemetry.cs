using IoT.Models.Robots;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;


namespace IoT.Models.RobotTelemetry
{

    public class RobTelemetryEntity
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public  Guid RobotId { get; set; }
        public RobotEntity Robot { get; set; } = null!;
        public string? DevType { get; set; }
       
        public float? PositionX { get; set; }
        public float? PositionY { get; set; }

        public int? BatteryLevel { get; set; }
        public float? Speed { get; set; }

        public string? Status { get; set; }
      
    }
}
