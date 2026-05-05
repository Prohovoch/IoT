
using IoT.Models.Hubs;
using System.ComponentModel.DataAnnotations.Schema;

namespace IoT.Models.Users
{
    [Table("Users")]
    public class User
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public required string Name { get; set; }
        public required string Surname {  get; set; }
        public int? Age { get; set; }
        
        public List<Hub>? Hubs;

    }
}


