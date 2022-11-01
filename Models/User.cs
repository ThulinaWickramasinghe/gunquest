using System.ComponentModel.DataAnnotations;

namespace RPG.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<Character>? Characters { get; set; }

        [Required]
        public string Role { get; set; }
    }
}