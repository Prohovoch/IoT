using System.ComponentModel.DataAnnotations;


namespace IoT.DTO.DeviceTelemetry
{
    public class DeviceTelemUpdate
    {
        
        
       
        public float? Temp { get; set; }
        public float? Press { get; set; }

        public int? BattLevel { get; set; }
        public string? Status { get; set; }


    }
}
