using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace formCreator.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string? Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string? LastName { get; set; }
        [Required]
        [Column(TypeName = "Date")] 
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string? Password { get; set; }
        public List<Form> PatientContactInfoPhones { get; set; }
    }
}
