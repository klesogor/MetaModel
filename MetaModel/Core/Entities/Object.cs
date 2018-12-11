using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MetaModel.Core.Entities
{
    public class Object: Base
    {
        [Required]
        public Type Type { get; set; }

        [Required]
        public List<Value> Values { get; set; }
    }
}
