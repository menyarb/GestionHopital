using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionHopital.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Name length can't be more than 20 characters.")]
        public string Name { get; set; }
        [EmailAddress]
        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(12, ErrorMessage = "Phone number length can't be more than 12 characters.")]
        public string Phone { get; set; }

        [StringLength(40, ErrorMessage = "Address length can't be more than 40 characters.")]
        public string Address { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(1, ErrorMessage = "Gender can only be 1 character.")]
        public string Gender { get; set; }
        public string role { get; set; }

        // Propriété de clé étrangère pour la relation avec Login
        [ForeignKey("LoginID")]
        public int? LoginID { get; set; }

        // Navigation property for Login
        public virtual Login Login { get; set; }
    }
}
