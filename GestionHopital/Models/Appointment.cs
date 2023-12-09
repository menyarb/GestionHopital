namespace GestionHopital.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Appointment
    {
        [Key]
        public int AppointID { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }

        [ForeignKey("Patient")]
        public int PatientID { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }

        public int Appointment_Status { get; set; }

        public float? Bill_Amount { get; set; }

        public int? Bill_Status { get; set; }

        [StringLength(30, ErrorMessage = "Disease length can't be more than 30 characters.")]
        public string Disease { get; set; }

        [StringLength(50, ErrorMessage = "Progress length can't be more than 50 characters.")]
        public string Progress { get; set; }

        [StringLength(60, ErrorMessage = "Prescription length can't be more than 60 characters.")]
        public string Prescription { get; set; }

        // Navigation properties
        public virtual Doctor Doctor { get; set; }

        public virtual User Patient { get; set; }

           }

}
