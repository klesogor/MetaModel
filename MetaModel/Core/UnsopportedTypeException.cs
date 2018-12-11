using System;
using System.Collections.Generic;
using System.Text;

namespace MetaModel.Core
{
    public class UnsopportedTypeException: Exception
    {
        public override string Message => "This type is not implemented yet";
    }
}
