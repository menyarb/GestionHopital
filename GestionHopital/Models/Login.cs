using System.ComponentModel.DataAnnotations;

public class Login
{
    [Key]
    public int LoginID { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(30)]
    public string Email { get; set; }

    [Required]
    public int Type { get; set; }
}
