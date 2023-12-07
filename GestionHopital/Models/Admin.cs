using System.ComponentModel.DataAnnotations;

namespace GestionHopital.Models
{
    public class Admin
    {

        [Key]
        public int AdminID { get; set; }

        [Required(ErrorMessage = "Admin Name is required.")]
        [StringLength(20, ErrorMessage = "Admin Name length can't be more than 20 characters.")]
        public string Name { get; set; }

        [StringLength(12, ErrorMessage = "Phone number length can't be more than 12 characters.")]
        public string Phone { get; set; }

        [StringLength(40, ErrorMessage = "Address length can't be more than 40 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Birth Date is required.")]
        public DateTime BirthDate { get; set; }
    }
}
