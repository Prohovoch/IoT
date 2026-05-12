using System.ComponentModel.DataAnnotations;

namespace IoT.DTO.Hubs
{
    public class HubsRequest
    {
        
        [MaxLength(50, ErrorMessage ="More than 50 chars")]
        public string? HubAlias { get; set;  }

        public bool? IsActive {get; set; }
    }
}
