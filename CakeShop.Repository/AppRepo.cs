namespace CakeShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This is a class with particular data.
    /// </summary>
    /// <typeparam name="T">T.</typeparam>
    public abstract class AppRepo<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// DbContext instance.
        /// </summary>
        protected DbContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppRepo{T}"/> class.
        /// </summary>
        /// <param name="ctx">DbContext.</param>
        protected AppRepo(DbContext ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// This is an abstarct method with no body havinf a particular info about data.
        /// </summary>
        /// <param name="entity">T.</param>
        /// <returns>int.</returns>
        public abstract int Add(T entity);

        /// <summary>
        /// This is method returns the data of database of a specific table.
        /// </summary>
        /// <returns>IQueryable.</returns>
        public IQueryable<T> GetAll()
        {
            return this.ctx.Set<T>();
        }

        /// <summary>
        /// This method retuens the particular class with data.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>T.</returns>
        public abstract T GetOne(int id);

        /// <summary>
        /// This method returns whether the data is been removed.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>bool.</returns>
        public bool Remove(int id)
        {
            T data = this.GetOne(id);
            return this.Remove(data);
        }

        /// <summary>
        /// This method removes the data with any specific class.
        /// </summary>
        /// <param name="data">General data input.</param>
        /// <returns>Bool.</returns>
        public bool Remove(T data)
        {
            if (this.GetAll().Contains(data))
            {
                this.ctx.Remove(data);
                this.ctx.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
