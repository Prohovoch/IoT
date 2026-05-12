using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;

namespace IoT.DTO.Robots
{
    public class RobotUpdate
    {
       
        public string DevAlias { get; set; } = null!;
    }
}
