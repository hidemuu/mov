﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Models
{
    public interface IHeightAdjustable
    {
        void Raise(float height);
        void Lower(float height);
    }
}