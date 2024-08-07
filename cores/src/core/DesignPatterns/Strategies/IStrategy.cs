﻿namespace Mov.Core.DesignPatterns.Strategies
{
    /// <summary>クラスの振る舞いを切り替える</summary>
    public interface IStrategy
    {
        bool Execute();
        string GetCode();
        string GetNextCode();
    }
}
