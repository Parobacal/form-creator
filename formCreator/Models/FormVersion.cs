using formCreator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtx.WebUI.Data.Models.eForms
{
    [Table("FormsVersions", Schema = "EF")]
    public class FormVersion
    {
        [Required] public int Id { get; set; }
        [Required] public Form Form { get; set; }
        public string Properties { get; set; }
        public string HTML { get; set; }
        [Required] public int Version { get; set; }
        public List<Content>? Content { get; set; }
        [Required] public bool IsLatestVersion { get; set; }
        [Required] public DateTimeOffset CreatedDate { get; set; }
    }
}
