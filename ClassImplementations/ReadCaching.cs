using CrudContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudClassImplementations
{
    public class ReadCaching<TEntity> : IRead<TEntity>
    {
        private IEnumerable<TEntity> allCachedEntities;

        private readonly IRead<TEntity> decorated;

        public ReadCaching(IRead<TEntity> decorated)
        {
            this.decorated = decorated;
        }

        public IEnumerable<TEntity> Readall()
        {
            if(allCachedEntities == null)
            {
                allCachedEntities = decorated.Readall();
            }

            return allCachedEntities;
        }

        public TEntity ReadOne(Guid identity)
        {
            return decorated.ReadOne(identity);
        }
    }
}
