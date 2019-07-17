using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassImplementations
{
    public class CreateReadUpdateDelete<TEntity> : IRead<TEntity>, ISave<TEntity>, IDelete<TEntity>
    {
        public void Delete(TEntity entity)
        {
            // TODO: Implement the method.
        }

        public IEnumerable<TEntity> ReadAll()
        {
            // TODO: Implement the method.
            return new List<TEntity>();
        }

        public TEntity ReadOne(Guid identity)
        {
            // TODO: Implement the method.
            return default(TEntity);
        }

        public void Save(TEntity entity)
        {
            // TODO: Implement the method.
        }
    }
}
