using CrudContracts;
using System;
using System.Collections.Generic;

namespace CrudClassImplementations
{
    public class CrudLogging<TEntity> : ICreateReadUpdateDelete<TEntity>
    {
        private readonly ICreateReadUpdateDelete<TEntity> decoratedCrud;
        private readonly ILog log;

        public CrudLogging(ICreateReadUpdateDelete<TEntity> decoratedCrud, ILog log)
        {
            this.decoratedCrud = decoratedCrud;
            this.log = log;
        }

        public void Create(TEntity entity)
        {
            log.LogMessage(string.Format("Creating entity of type {0}", typeof(TEntity).Name));
            decoratedCrud.Create(entity);
        }

        public TEntity ReadOne(Guid identity)
        {
            log.LogMessage(string.Format("Reading entity of type {0} with identity {1}", typeof(TEntity).Name, identity));
            return decoratedCrud.ReadOne(identity);
        }

        public IEnumerable<TEntity> ReadAll()
        {
            log.LogMessage(string.Format("Reading all entities of type { 0}", typeof(TEntity).Name));
            return decoratedCrud.ReadAll();
        }

        public void Update(TEntity entity)
        {
            log.LogMessage(string.Format("Updating entity of type {0}.", typeof(TEntity).Name));
            decoratedCrud.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            log.LogMessage(string.Format("Deleting entity of type {0}", typeof(TEntity).Name));
            decoratedCrud.Delete(entity);
        }

    }
}
