namespace CakeShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CakeShop.Data;

    /// <summary>
    /// It interface stores the info about baker from the table.
    /// </summary>
    public interface IBakerRepository : IRepository<Baker>
    {
        /// <summary>
        /// This method updates the salary of the baker.
        /// </summary>
        /// <param name="bakerId">bakets Id.</param>
        /// <param name="salary">new salary.</param>
        void UpdateSalary(int bakerId, int salary);

        /// <summary>
        /// this method edits the baker with his id.
        /// </summary>
        /// <param name="id">bakerId.</param>
        /// <param name="bakerModified">Modifiedbaker.</param>
        void EditBaker(int id, Baker bakerModified);
    }
}
