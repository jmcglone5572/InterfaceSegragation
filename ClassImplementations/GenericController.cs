using Contracts;
using System;
using System.Collections.Generic;

namespace ClassImplementations
{
    public class GenericController<TEntity> 
    {
        private readonly IRead<TEntity> reader;
        private readonly ISave<TEntity> saver;
        private readonly IDelete<TEntity> deleter;
        
        public GenericController(IRead<TEntity> reader, ISave<TEntity> saver, IDelete<TEntity> deleter)
        {
            this.reader = reader;
            this.saver = saver;
            this.deleter = deleter;
        }

        public void Create(TEntity entity)
        {
            saver.Save(entity);
        }

        public void Delete(TEntity entity)
        {
            deleter.Delete(entity);
        }

        public IEnumerable<TEntity> ReadAll()
        {
            return reader.ReadAll();
        }

        public TEntity ReadOne(Guid identity)
        {
            return reader.ReadOne(identity);
        }

        public void Update(TEntity entity)
        {
            saver.Save(entity);
        }

    }
}
