using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionHopital.Models
{
    public class Role
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Role Name is required.")]
        [StringLength(20, ErrorMessage = "Role Name length can't be more than 20 characters.")]
        public string RoleName { get; set; }
        
    }
}
