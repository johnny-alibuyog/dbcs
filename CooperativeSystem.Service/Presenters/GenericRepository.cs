using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;

namespace CooperativeSystem.Service.Presenters
{
    internal class GenericRepository<T> : IRepository<T>
        where T : class
    {
        private DataContext _db;

        protected DataContext Db
        {
            get { return _db; }
        }

        #region Properties

        protected virtual string PrimaryKeyName
        {
            get { return TableMetadata.RowType.IdentityMembers[0].Name; }
        }

        protected virtual Table<T> Table
        {
            get { return Db.GetTable<T>(); }
        }

        protected virtual MetaTable TableMetadata
        {
            get { return Db.Mapping.GetTable(typeof(T)); }
        }

        protected virtual MetaType ClassMetadata
        {
            get { return Db.Mapping.GetMetaType(typeof(T)); }
        }

        #endregion

        #region Constructors

        public GenericRepository() : 
            this(new DataContextFactory().CreateDataContext()) { }

        public GenericRepository(DataContext db)
        {
            _db = db;
        }

        #endregion

        #region IRepository<T> Members

        /// <summary>
        /// Return all instances of type T.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return Table;
        }

        /// <summary>
        /// Return all instances of type T that match the expression exp.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> exp)
        {
            return Table.Where<T>(exp);
        }

        /// <summary>
        /// Returns the first element of a sequence, or a default value if the sequence
        /// contains no elements.
        /// </summary>
        /// <returns></returns>
        public virtual T GetEntity()
        {
            return Table.FirstOrDefault();
        }

        /// <summary>
        /// Returns the first element of a sequence that satisfies a specified condition
        /// or a default value if no such element is found.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public virtual T GetEntity(Expression<Func<T, bool>> exp)
        {
            return Table.FirstOrDefault(exp);
        }

        /// <summary>
        /// Create a new instance of type T and insert entity when context is saved.
        /// </summary>
        /// <returns></returns>
        public virtual T CreateEntity()
        {
            T entity = Activator.CreateInstance<T>();
            Table.InsertOnSubmit(entity);
            return entity;
        }

        /// <summary>
        /// Mark an entity to be deleted when the context is saved.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void MarkForDeletion(T entity)
        {
            Table.DeleteOnSubmit(entity);
        }

        /// <summary>
        /// Mark entities to be deleted when the context is saved.
        /// </summary>
        /// <param name="entities"></param>
        public virtual void MarkForDeletion(IEnumerable<T> entities)
        {
            Table.DeleteAllOnSubmit(entities);
        }

        /// <summary>
        /// Persist the data context.
        /// </summary>
        public virtual void SaveAll()
        {
            Db.SubmitChanges();
        }

        #endregion
    }
}