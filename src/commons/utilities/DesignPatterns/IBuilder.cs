﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.DesignPatterns
{
    public interface IBuilder<T>
    {
        T Build();
    }
}