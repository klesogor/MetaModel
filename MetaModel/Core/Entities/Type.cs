using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MetaModel.Core.Entities
{
    public class Type: Base
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public List<Object> Objects { get; set; }
        [Required]
        public List<Attribute> Attributes { get; set; }
    }
}
