namespace CakeShop.Logic
{
    using CakeShop.Data;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The interface keeps all the methods to be implemented in the Admin class.
    /// </summary>
    public interface IAdminManagement
    {
        /// <summary>
        /// This method checks if it removes the baker based on the id.
        /// </summary>
        /// <param name="id">int id.</param>
        /// <returns>bool.</returns>
        bool RemoveBaker(int id);

        /// <summary>
        /// this method sees if the cake is removed from the database from its id.
        /// </summary>
        /// <param name="id">int id.</param>
        /// <returns>bool.</returns>
        bool RemoveCake(int id);

        /// <summary>
        /// This method checks if the delivery is deketed from the database or not.
        /// </summary>
        /// <param name="id">int id.</param>
        /// <returns>bool.</returns>
        bool RemoveDelivery(int id);

        /// <summary>
        /// This method updates the bakrsalary.
        /// </summary>
        /// <param name="bakerId">bakerid.</param>
        /// <param name="salary">int salary.</param>
        void UpdateBakerSalary(int bakerId, int salary);

        /// <summary>
        /// this lists the baker's average cake price result.
        /// </summary>
        /// <returns>List of Average price.</returns>
        IList<AveragesResult> GetBakerCakePriceAverage();

        /// <summary>
        /// This lists the cakes been delivered.
        /// </summary>
        /// <returns>Lists of cake deliveries.</returns>
        IList<CakesDelivery> CakesDeliveries();

        /// <summary>
        /// this lists the income earned by the baker.
        /// </summary>
        /// <returns>lists of income by baker.</returns>
        IList<IncomeByBaker> TotalIncomeByBaker();

        /// <summary>
        /// Gets one cake.
        /// </summary>
        /// <returns>Cake.</returns>
        public Cake GetOne();

        /// <summary>
        /// This method selects one cake.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Bool.</returns>
        public bool SelectCake(int id);

        /// <summary>
        /// This method unselects onr cake.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Bool.</returns>
        public bool UnSelectCake(int id);

        /// <summary>
        /// This method unselects the guests.
        /// </summary>
        /// <returns>CakeList.</returns>
        public List<Cake> UnSelectedGuests();

        /// <summary>
        /// This method selevcts the guests.
        /// </summary>
        /// <returns>cakeList.</returns>
        public List<Cake> SelectedGuests();
    }
}
