using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MetaModel.Core.Entities
{
    public abstract class Base
    {
        [Key]
        public Guid Id { get; set; }
    }
}
