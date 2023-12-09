﻿namespace GestionHopital.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OtherStaff
    {
        [Key] 
        public int StaffID { get; set; }

  
        [Required(ErrorMessage = "Designation is required.")]
        [StringLength(15, ErrorMessage = "Designation length can't be more than 15 characters.")]
        public string Designation { get; set; }

      
        [StringLength(20, ErrorMessage = "Highest Qualification length can't be more than 20 characters.")]
        public string Highest_Qualification { get; set; }

        public float? Salary { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        // Navigation property for Doctor
        public virtual Doctor Doctor { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        // Navigation property for User
        public virtual User user { get; set; }


    }

}
