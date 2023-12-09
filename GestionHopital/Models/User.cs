using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionHopital.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = " Name is required.")]
        [StringLength(20, ErrorMessage = " Name length can't be more than 20 characters.")]
        public string Name { get; set; }
        [EmailAddress]
        [StringLength(30)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [StringLength(12, ErrorMessage = "Phone number length can't be more than 12 characters.")]

        public string Phone { get; set; }

        [StringLength(40, ErrorMessage = "Address length can't be more than 40 characters.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
        [StringLength(1, ErrorMessage = "Gender can only be 1 character.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Birth Date is required.")]
        public DateTime BirthDate { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        // Navigation property for Doctor
        public virtual Role role { get; set; }

    }
}
