using System;

namespace Mov.Core.Stores.Services.Deleters.Decorators
{
    public class DeleteConfirmation<TEntity, TKey> : IDelete<TEntity, TKey>
    {
        private readonly IDelete<TEntity, TKey> decorated;

        public DeleteConfirmation(IDelete<TEntity, TKey> decorated)
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
