
using IoT.Models.Hubs;
using System.ComponentModel.DataAnnotations.Schema;

namespace IoT.Models.Users
{
    [Table("Users")]
    public class User
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int? Age { get; set; } 
        
        public ICollection<Hub>? Hubs;

    }
}


