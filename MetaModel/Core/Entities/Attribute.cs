using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MetaModel.Core.Entities
{
    public class Attribute : Base
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Type Type { get; set; }

        [Required]
        public List<Value> Values {get;set;}
    }
}
