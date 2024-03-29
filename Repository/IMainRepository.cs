﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IMainRepository<T> where T : class
    {
        // Get all Entites => (get all customers, get all products ...etc)
        IQueryable<T> GetAll();

        // Get Entity by his ID => (get a customer by his ID)
        T GetById(int id);

        // Get Entity by matching given expression
        T Find(Expression<Func<T, bool>> criteria, params Expression<Func<T, object>>[] includes);

        IQueryable<T> FindAll(Expression<Func<T, bool>> criteria, params Expression<Func<T, object>>[] includes);

        // Add any Entity => (add customer, add seller ...et)
        void Add(T entity);

        // Remove an Entity => (remove a customer, remove a seller ...etc)
        void Remove(T entity);

        void RemoveById(int id);

        // Update Entity info => (update Customer's Info ...etc)
        void Update(T entity);

    }
}
