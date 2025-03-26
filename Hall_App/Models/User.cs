using System.ComponentModel.DataAnnotations;

namespace Hall_App.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Roll { get; set; } = string.Empty;
    }
}
