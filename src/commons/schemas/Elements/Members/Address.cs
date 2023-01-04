using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Elements.Members
{
    public sealed class Address
    {
        public string StreetAddress { get; set; }

        public string Postcode { get; set; }

        public string City { get; set;  }
    }
}
