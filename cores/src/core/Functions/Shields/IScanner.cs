﻿using Mov.Core.Models.ValueObjects.Units;

namespace Mov.Core.Functions.Shields
{
    public interface IScanner
    {
        void Scan(Document document);
    }
}