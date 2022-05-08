namespace CakeShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CakeShop.Data;

    /// <summary>
    /// This interface stores the info about the delivery table and has a updatemethod.
    /// </summary>
    public interface IDeliveryRepository : IRepository<Delivery>
    {
        /// <summary>
        /// This method updates the name of the delivery person.
        /// </summary>
        /// <param name="deliveryId">Id of delivery man.</param>
        /// <param name="name">updates name.</param>
        void UpdateDeliveryPersonName(int deliveryId, string name);
    }
}
