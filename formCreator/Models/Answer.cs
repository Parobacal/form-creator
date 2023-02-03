using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace formCreator.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        [Required]
        [Column(TypeName = "varchar(250)")]
        public string? Data { get; set; }
        [Required]
        public int ContentId { get; set; }
        [JsonIgnore]
        public Content? Content { get; set; }
    }
}
