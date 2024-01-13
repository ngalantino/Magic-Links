using System.ComponentModel.DataAnnotations;

namespace MagicLinks
{
    public class LoginModel
    {
        public string? UserName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }

}