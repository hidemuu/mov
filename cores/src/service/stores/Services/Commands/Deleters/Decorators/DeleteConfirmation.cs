using System;

namespace Mov.Core.Stores.Services.Commands.Deleters.Decorators
{
    public class DeleteConfirmation<TEntity, TKey> : IDelete<TEntity>
    {
        private readonly IDelete<TEntity> decorated;

        public DeleteConfirmation(IDelete<TEntity> decorated)
        {
            this.decorated = decorated;
        }

        public void Delete(TEntity entity)
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
