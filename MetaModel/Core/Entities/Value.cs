using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MetaModel.Core.Entities
{
    public class Value: Base
    {
        public string Data { get; set; }

        [Required]
        public Attribute Attribute { get; set; }
        
        [Required]
        public Object Object { get; set; }
    }
}
