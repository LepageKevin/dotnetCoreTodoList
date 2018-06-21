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

        public IEnumerable FindAll()
        {
            return ApplicationDbContext.Set<T>().ToList();
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

        public void Delete(T entity)
        {
            ApplicationDbContext.Set<T>().Remove(entity);
            ApplicationDbContext.SaveChanges();
        }
    }
}
