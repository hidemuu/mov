﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
{
    internal interface ISpecification<T>
    {
        bool IsSatisfied(T spec);
    }
}