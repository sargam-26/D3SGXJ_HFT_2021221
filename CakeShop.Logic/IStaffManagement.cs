namespace CakeShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CakeShop.Data;

    /// <summary>
    /// this interface stores the info of the staff.
    /// </summary>
    public interface IStaffManagement
    {
        /// <summary>
        /// This return the list of all bakers.
        /// </summary>
        /// <returns>list.</returns>
        IList<Baker> GetAllBaker();

        /// <summary>
        /// based on the id of baker, returns the baker info.
        /// </summary>
        /// <param name="bakerId">id.</param>
        /// <returns>bakerinfo.</returns>
        Baker GetBakerInfo(int bakerId);

        /// <summary>
        /// ths method updates the delivery person name.
        /// </summary>
        /// <param name="deliveryId">id.</param>
        /// <param name="name">name.</param>
        void UpdateDeliveryPersonName(int deliveryId, string name);

        /// <summary>
        /// this method adds baler info on the given parameters into the datbase.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="position">position.</param>
        /// <param name="salary">salary.</param>
        /// <param name="workHours">worktimehrs.</param>
        void AddBaker(string name, string position, int salary, int workHours);
    }
}
