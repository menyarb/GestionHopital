namespace GestionHopital.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OtherStaff
    {
        [Key] 
        public int StaffID { get; set; }

        [Required(ErrorMessage = "Staff Name is required.")]
        [StringLength(20, ErrorMessage = "Staff Name length can't be more than 20 characters.")]
        public string Name { get; set; }
        [EmailAddress]
        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(12, ErrorMessage = "Phone number length can't be more than 12 characters.")]
        public string Phone { get; set; }

        [StringLength(30, ErrorMessage = "Address length can't be more than 30 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Designation is required.")]
        [StringLength(15, ErrorMessage = "Designation length can't be more than 15 characters.")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [StringLength(1, ErrorMessage = "Gender can only be 1 character.")]
        public string Gender { get; set; }
        public string role { get; set; }
        public DateTime? BirthDate { get; set; }

        [StringLength(20, ErrorMessage = "Highest Qualification length can't be more than 20 characters.")]
        public string Highest_Qualification { get; set; }

        public float? Salary { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        // Navigation property for Doctor
        public virtual Doctor Doctor { get; set; }
        

    }

}
