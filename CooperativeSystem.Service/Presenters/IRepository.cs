using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CooperativeSystem.Service.Presenters
{
    internal interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> exp);
        T GetEntity();
        T GetEntity(Expression<Func<T, bool>> exp);
        T CreateEntity();
        void MarkForDeletion(T entity);
        void MarkForDeletion(IEnumerable<T> entities);
        void SaveAll();
    }
}