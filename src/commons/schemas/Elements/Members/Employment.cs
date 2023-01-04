using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Elements.Members
{
    public sealed class Employment
    {
        public string CompanyName { get; }

        public string Position { get; }

        public Employment(string companyName, string position) 
        {
            CompanyName = companyName;
            Position= position;
        }

    }
}
