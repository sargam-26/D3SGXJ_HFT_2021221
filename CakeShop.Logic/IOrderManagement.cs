namespace CakeShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CakeShop.Data;

    /// <summary>
    /// this interface stores the method to be implemented in the OrderManagement  class.
    /// </summary>
    public interface IOrderManagement
    {
        /// <summary>
        /// this lists all the cakes from the database.
        /// </summary>
        /// <returns>lists the cakes.</returns>
        IList<Cake> GetAllCakes();

        /// <summary>
        /// This gets the cake info upon cake id.
        /// </summary>
        /// <param name="cakeId">cakeid.</param>
        /// <returns>Cake.</returns>
        Cake GetCakeInfo(int cakeId);

        /// <summary>
        /// this method updates the cake shape upon id.
        /// </summary>
        /// <param name="cakeId">cakeid.</param>
        /// <param name="shape">shape.</param>
        void UpdateCakeShape(int cakeId, string shape);
        /// <summary>
        /// This method updates the cake info.
        /// </summary>
        /// <param name="cakeId">cake obj.</param>
        /// <param name="name">cake name.</param>
        /// <param name="shape">cake shape.</param>
        /// <param name="color">cake color.</param>
        /// <param name="bakerId">cake bakerid.</param>
        /// <param name="basePrice">cake price.</param>
        public void UpdateCake(int cakeId, string name, string shape, string color, int bakerId, int basePrice);

        /// <summary>
        /// This method retrnsthe delivery info fromt he delivery database.
        /// </summary>
        /// <param name="deliveryId">id.</param>
        /// <returns>delivery.</returns>
        Delivery GetDeliveryInfo(int deliveryId);

        /// <summary>
        /// this method adds the cake whole info into the daatabse which will be implemeted later in the class..
        /// </summary>
        /// <param name="name">cakename.</param>
        /// <param name="shape">cakeshape.</param>
        /// <param name="color">cakecolor.</param>
        /// <param name="price">cakeprice.</param>
        /// <param name="deliveryId">deliveryid.</param>
        /// <param name="bakerId">bakerid.</param>
        /// <param name="basePrice">baseprice.</param>
        void AddCake(string name, string shape, string color, int price, int deliveryId, int bakerId, int basePrice);

        /// <summary>
        /// this method adds the cake whole info into the daatabse which will be implemeted later in the class..
        /// </summary>
        /// <param name="name">cakename.</param>
        /// <param name="shape">cakeshape.</param>
        /// <param name="color">cakecolor.</param>
        /// <param name="bakerId">bakerid.</param>
        /// <param name="basePrice">baseprice.</param>
        public void AddCake(string name, string shape, string color, int bakerId, int basePrice);

        /// <summary>
        /// This lists the deliveries.
        /// </summary>
        /// <returns>list of all deliveries.</returns>
        IList<Delivery> GetDeliveries();

        /// <summary>
        /// this method add the delivery info to the database.
        /// </summary>
        /// <param name="name">personname.</param>
        /// <param name="income">incomeearned.</param>
        /// <param name="time">timetaken.</param>
        /// <param name="schedule">schedule.</param>
        void AddDelivery(string name, int income, int time, int schedule);
    }
}
