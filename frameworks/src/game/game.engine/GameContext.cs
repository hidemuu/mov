﻿using Mov.Game.Engine.Persistences;
using Mov.Game.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Repository
{
    public class GameContext : IGameContext
    {
        public IGameRepository Repository { get; }

        public IGameCommand Command { get; }

        public IGameQuery Query { get; }

        public GameContext(IGameRepository repository)
        {
            this.Repository = repository;
            this.Command = new RepositoryGameCommand(repository);
            this.Query = new RepositoryGameQuery(repository);
        }

        
    }
}