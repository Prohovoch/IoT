using System.ComponentModel.DataAnnotations;

namespace IoT.DTO.Devices
{
    public class DeviceRequest
    {
        public Guid HubId { get;set; }

        [MaxLength(50, ErrorMessage ="More than 50 chars")]
        public string? DevAlias { get; set; }

    }
}
