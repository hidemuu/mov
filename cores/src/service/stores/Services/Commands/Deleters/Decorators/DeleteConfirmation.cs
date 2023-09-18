using System;

namespace Mov.Core.Stores.Services.Commands.Deleters.Decorators
{
    public class DeleteConfirmation<TEntity> : IDelete<TEntity>
    {
        private readonly IDelete<TEntity> _decorated;

        public DeleteConfirmation(IDelete<TEntity> decorated)
        {
            _decorated = decorated;
        }

        public void Delete(TEntity entity)
        {
            Console.WriteLine("削除しますか？ [Y/N]");
            var keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Y)
            {
                _decorated.Delete(entity);
            }
        }

    }
}
