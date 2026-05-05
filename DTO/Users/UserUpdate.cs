using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IoT.DTO.Users
{
    public class UserUpdate
    {
        
        [Required]
        [MaxLength(50, ErrorMessage = "Entered more than 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50, ErrorMessage = "Entered more than 50 characters")]
        public string Surname {get; set;} = string.Empty;

        [Range(0,100, ErrorMessage = "Bad value.")]
        public int? Age { get; set;}
    }
}
