﻿using System;
using System.Collections.Generic;
using System.Text;
using Mov.Utilities.Templates.Crud;

namespace Mov.Controllers.Models.Decorator
{
    public class DeleteConfirmation<T> : IDelete<T>
    {
        private readonly IDelete<T> decorated;

        public DeleteConfirmation(IDelete<T> decorated)
        {
            this.decorated = decorated;
        }

        public void Delete(T entity)
        {
            Console.WriteLine("削除しますか？ [Y/N]");
            var keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Y)
            {
                decorated.Delete(entity);
            }
        }

    }
}