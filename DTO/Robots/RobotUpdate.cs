using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;

namespace IoT.DTO.Robots
{
    public class RobotUpdate
    {
        [Required]
        [MaxLength(50, ErrorMessage ="More than 50 chars.")]
        public string? DevAlias { get; set; }
    }
}
