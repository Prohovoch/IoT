namespace IoT.DTO.Robots
{
    public class RobotResponse
    {
       
        public Guid HubId { get; init; }
        public string? DevAlias { get; init;  }
        
    
    }

    public class RobotResponseExtra : RobotResponse { 
    
        // ....
        // ....

    }
}
