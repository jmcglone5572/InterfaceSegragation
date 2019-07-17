using Contracts;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace ClassImplementations
{
    public class CrudTransactional<TEntity> : ICreateReadUpdateDelete<TEntity>
    {
        private readonly ICreateReadUpdateDelete<TEntity> decoratedCrud;

        public CrudTransactional(ICreateReadUpdateDelete<TEntity> decoratedCrud)
        {
            this.decoratedCrud = decoratedCrud;
        }

        public void Create(TEntity entity)
        {
            using (var transaction = new TransactionScope())
            {
                decoratedCrud.Create(entity);
                transaction.Complete();
            }
        }

        public IEnumerable<TEntity> ReadAll()
        {
            IEnumerable<TEntity> result;
            using (var transaction = new TransactionScope())
            {
                result = decoratedCrud.ReadAll();
                transaction.Complete();
            }

            return result;
        }

        public TEntity ReadOne(Guid identity)
        {
            TEntity result;

            using (var transaction = new TransactionScope())
            {
                result = decoratedCrud.ReadOne(identity);
                transaction.Complete();
            }

            return result;
        }

        public void Update(TEntity entity)
        {
            using (var transaction = new TransactionScope())
            {
                decoratedCrud.Update(entity);

                transaction.Complete();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var transaction = new TransactionScope())
            {
                decoratedCrud.Delete(entity);
                transaction.Complete();
            }
        }

    }
}
