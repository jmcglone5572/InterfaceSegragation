using Contracts;
using System;
using System.Collections.Generic;

namespace CrudClassImplementations
{
    public class DeleteConfirmation<TEntity> : IDelete<TEntity>
    {
        private readonly IDelete<TEntity> decoratedCrud;
        public DeleteConfirmation(IDelete<TEntity> decoratedCrud)
        {
            this.decoratedCrud = decoratedCrud;
        }

        public void Delete(TEntity entity)
        {
            Console.WriteLine("Are you sure you want to delete the entity?(y/N)");
            var keyInfo = Console.ReadKey();
            if(keyInfo.Key == ConsoleKey.Y)
            {
                decoratedCrud.Delete(entity);
            }
        }
    }
}
