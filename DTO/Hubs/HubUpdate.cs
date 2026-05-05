using System.ComponentModel.DataAnnotations;

namespace IoT.DTO.Hubs
{
    public class HubUpdate
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Entered more than 50 characters")]
        public string? HubAlias { get; set; }

        [Required]
        public bool? isActive { get; set; }

        
    }
}
