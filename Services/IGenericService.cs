using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace todoList.Services
{
    public interface IGenericService<TEntity>
    {
        IEnumerable<TEntity> FindAll();
        TEntity FindById(int id);

        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
