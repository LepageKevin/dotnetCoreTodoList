using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using todoList.Data;

namespace todoList.Services
{
    public abstract class GenericService<T> : IGenericService<T>
        where T: class
    {
        protected ApplicationDbContext ApplicationDbContext { get; private set; }

        public GenericService(ApplicationDbContext applicationDbContext) 
        {
            ApplicationDbContext = applicationDbContext;
        }

        public IEnumerable<T> FindAll()
        {
            return ApplicationDbContext.Set<T>();
        }

        protected IQueryable<T> FindAllIncluable()
        {
            return ApplicationDbContext.Set<T>();
        }

        public T FindById(int id)
        {
            return ApplicationDbContext.Set<T>().Find(id);
        }

        public void Create(T entity)
        {
            ApplicationDbContext.Set<T>().Add(entity);
            ApplicationDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            ApplicationDbContext.Set<T>().Update(entity);
            ApplicationDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            T value = FindById(id);
            ApplicationDbContext.Set<T>().Remove(value);
            ApplicationDbContext.SaveChanges();
        }
    }
}
