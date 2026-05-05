
using IoT.Models.Hubs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IoT.Models.Users
{
    [Table("Users")]
    public class User
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();


        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int? Age { get; set; }

        // 1 : m relations
        public ICollection<Hub> Hubs { get; } = new List<Hub>();

    }
}


