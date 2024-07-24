﻿using System.ComponentModel.DataAnnotations;

namespace e_Clinic.DataAccess.Entities
{
    public class BaseUser
    {
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; } 

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string? Gender { get; set; } 

        [Required]
        public string? ContactNumber { get; set; }

        [Required]
        public string? Email { get; set; } 

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
