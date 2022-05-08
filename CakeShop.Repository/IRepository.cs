namespace CakeShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// This is a general interface for a specific class.
    /// </summary>
    /// <typeparam name="T">class.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// This method returns the data available in the particular table.
        /// </summary>
        /// <returns>General class.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Gets the general id from the particular class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>class.</returns>
        T GetOne(int id);

        /// <summary>
        /// This method adds new entity.
        /// </summary>
        /// <param name="entity">General.</param>
        /// <returns>class.</returns>
        public int Add(T entity);

        /// <summary>
        /// Thismethod removes the id from the paticular class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>bool.</returns>
        public bool Remove(int id);
    }
}
