using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IoT.DTO.Users
{
    public class UserCreation
    {
       
        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;
        public int? Age { get; set; }


    }
}
