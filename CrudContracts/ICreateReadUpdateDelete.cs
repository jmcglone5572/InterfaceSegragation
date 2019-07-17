﻿using System;
using System.Collections.Generic;

namespace CrudContracts
{
    public interface ICreateReadUpdateDelete<TEntity>
    {
        void Create(TEntity entity);

        TEntity ReadOne(Guid identity);

        IEnumerable<TEntity> ReadAll();

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
