using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IoT.DTO.Users
{
    public class UserCreation
    {
        [Required]
        [MinLength(3), MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(3), MaxLength(50)]
        public string Surname { get; set; } = null!;
        public int? Age { get; set; }


    }
}
