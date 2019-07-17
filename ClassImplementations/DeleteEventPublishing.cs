using Contracts;
using CrudContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudClassImplementations
{
    class DeleteEventPublishing<TEntity> : IDelete<TEntity>
    {
        private readonly IDelete<TEntity> decorated;
        private readonly IEventPublisher eventPublisher;

        public DeleteEventPublishing(IDelete<TEntity> decorated, IEventPublisher eventPublisher)
        {
            this.decorated = decorated;
            this.eventPublisher = eventPublisher;
        }

        public void Delete(TEntity entity)
        {
            decorated.Delete(entity);
            var entityDeleted = new EntityDeletedEvent<TEntity>(entity);
            eventPublisher.Publish(entityDeleted);
        }
    }
}
