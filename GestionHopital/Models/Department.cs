namespace GestionHopital.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Department
    {
        [Key]
        public int DeptNo { get; set; }

        [Required(ErrorMessage = "Department Name is required.")]
        [StringLength(20, ErrorMessage = "Department Name length can't be more than 20 characters.")]
        [Display(Name = "Department Name")]  // Display attribute for better label in views
        public string DeptName { get; set; }

        [StringLength(100, ErrorMessage = "Description length can't be more than 100 characters.")]
        public string Description { get; set; }
        public string img { get; set; }

    }

}
