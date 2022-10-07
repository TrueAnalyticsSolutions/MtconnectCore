using System.ComponentModel.DataAnnotations;

namespace MtconnectCoreDocumentation.Models
{
    public class DataItemTypeReference
    {
        [Required]
        public string Type { get; set; }

        public string SubType { get; set; }
    }
}
