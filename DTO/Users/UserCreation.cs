using System.ComponentModel.DataAnnotations;

namespace IoT.DTO.Users
{
    public class UserCreation
    {
        
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public int? Age { get; set; }


    }
}
