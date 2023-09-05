using System.ComponentModel.DataAnnotations;

namespace LauraModasAPI.Dtos.UserDtos
{
    public class LoginUserDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
