using Contracts;
using System;
using System.Collections.Generic;

namespace ClassImplementations
{
    public class ReadCaching<TEntity> : IRead<TEntity>
    {
        private IEnumerable<TEntity> allCachedEntities;

        private readonly IRead<TEntity> decorated;

        public ReadCaching(IRead<TEntity> decorated)
        {
            this.decorated = decorated;
        }

        public IEnumerable<TEntity> ReadAll()
        {
            if(allCachedEntities == null)
            {
                allCachedEntities = decorated.ReadAll();
            }

            return allCachedEntities;
        }

        public TEntity ReadOne(Guid identity)
        {
            return decorated.ReadOne(identity);
        }
    }
}
