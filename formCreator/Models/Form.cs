using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace formCreator.Models
{
    public class Form
    {
        [Key]
        public int FormId { get; set; }
        [Required]
        [Column(TypeName = "varchar(45)")]
        public string? Name { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string? Description { get; set; }
        
        [Required]
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}
