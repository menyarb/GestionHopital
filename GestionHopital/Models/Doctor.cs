namespace GestionHopital.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }

        [Required(ErrorMessage = "Doctor Name is required.")]
        [StringLength(20, ErrorMessage = "Doctor Name length can't be more than 20 characters.")]
        public string Name { get; set; }

        [StringLength(12, ErrorMessage = "Phone number length can't be more than 12 characters.")]
        public string Phone { get; set; }

        [StringLength(40, ErrorMessage = "Address length can't be more than 40 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Birth Date is required.")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [StringLength(1, ErrorMessage = "Gender can only be 1 character.")]
        public string Gender { get; set; }

        [ForeignKey("Department")]
        public int DeptNo { get; set; }

        [Required(ErrorMessage = "Charges Per Visit is required.")]
        public float Charges_Per_Visit { get; set; }

        public float? MonthlySalary { get; set; }

        public float? ReputeIndex { get; set; }

        [Required(ErrorMessage = "Number of Patients Treated is required.")]
        public int Patients_Treated { get; set; }

        [Required(ErrorMessage = "Qualification is required.")]
        [StringLength(50, ErrorMessage = "Qualification length can't be more than 50 characters.")]
        public string Qualification { get; set; }

        [StringLength(50, ErrorMessage = "Specialization length can't be more than 50 characters.")]
        public string Specialization { get; set; }

        public int? Work_Experience { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public int Status { get; set; }

        // Navigation property for Department
        public virtual Department Department { get; set; }
    }

}
