using System;
using System.ComponentModel.DataAnnotations;

namespace MtconnectCoreDocumentation.Models
{

    public class DataItemTypeViewModel
    {
        [Required]
        public object Type { get; set; }

        public object? SubType { get; set; }
    }
    public class DataItemTypeReference
    {
        public Enum Category { get; set; }

        public object Type { get; set; }

        public Enum? SubTypes { get; set; }
    }
}
