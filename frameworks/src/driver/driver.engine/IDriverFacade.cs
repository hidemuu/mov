﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Models
{
    public interface IDriverFacade
    {
        IDriverRepository Repository { get; }
    }
}