﻿namespace Mov.Core.Models.ValueObjects.Commands
{
    public enum CommandStatus
    {
        Nothing = 0,
        Posted = 1,
        Registered = 2,
        Finished = 3,
        Canceled = 4,
    }
}