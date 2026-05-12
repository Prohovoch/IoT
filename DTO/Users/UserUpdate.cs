using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IoT.DTO.Users
{
    public class UserUpdate
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

       
        public string Surname {get; set;} = string.Empty;

     
        public int Age { get; set;}
    }
}
