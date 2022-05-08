namespace CakeShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CakeShop.Data;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class stores the query related to the delivery table.
    /// </summary>
    public class DeliveryRepository : AppRepo<Delivery>, IDeliveryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryRepository"/> class.
        /// </summary>
        /// <param name="ctx">DbContext.</param>
        public DeliveryRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// This methods adds the delivery data to the delivery table.
        /// </summary>
        /// <param name="entity">entity.</param>
        /// <returns>int.</returns>
        public override int Add(Delivery entity)
        {
            if (entity == null)
            {
                throw new Exception();
            }

            this.ctx.Set<Delivery>().Add(entity);
            this.ctx.SaveChanges();
            return entity.Id;
        }

        /// <summary>
        /// This method returns the delivery man witht he particular id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>Delivery.</returns>
        public override Delivery GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// This method updates the name of the delivery man.
        /// </summary>
        /// <param name="deliveryId">id.</param>
        /// <param name="name">name.</param>
        public void UpdateDeliveryPersonName(int deliveryId, string name)
        {
            var delivery = this.GetOne(deliveryId);
            if (delivery == null)
            {
                throw new InvalidOperationException();
            }

            delivery.Person = name;
            this.ctx.SaveChanges();
        }
    }
}
