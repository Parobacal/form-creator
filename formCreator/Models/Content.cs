using formCreator.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace formCreator.Models
{
    public class Content
    {
        [Key]
        public int ContentId { get; set; }
        [Required]
        [Column(TypeName = "varchar(45)")]
        public string? Title { get; set; }
        [Required]
        public ContentType Type { get; set; }
        [Required]
        public int Required { get; set; }
        public List<Answer>? Answer { get; set; }
        [Required]
        public int FormId { get; set; }
        [JsonIgnore]
        public Form? Form { get; set; }

    }
}
