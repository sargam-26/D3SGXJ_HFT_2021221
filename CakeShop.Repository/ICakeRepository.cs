namespace CakeShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CakeShop.Data;

    /// <summary>
    /// This interface stores the info about cake table.
    /// </summary>
    public interface ICakeRepository : IRepository<Cake>
    {/// <summary>
     /// This method updates the cake shape upon two given arguments.
     /// </summary>
     /// <param name="cakeId">cakeId of the cake.</param>
     /// <param name="shape">changes shape.</param>
        void UpdateCakeShape(int cakeId, string shape);

        /// <summary>
        /// this method updates the cake.
        /// </summary>
        /// <param name="cakeId">Id.</param>
        /// <param name="name">Cake obj.</param>
        /// <param name="shape">Cake shape.</param>
        /// <param name="color">cake color.</param>
        /// <param name="bakerId">cake bakerid.</param>
        /// <param name="basePrice">cake price.</param>
        public void UpdateCake(int cakeId, string name, string shape, string color, int bakerId, int basePrice);

        /// <summary>
        /// This is random cake method.
        /// </summary>
        /// <returns>Cake.</returns>
        public Cake RandomCake();

        /// <summary>
        /// This method search the cake from the databse.
        /// </summary>
        /// <param name="name">name.</param>
        /// <returns>cake.</returns>
        IQueryable<Cake> Search(string name);

        /// <summary>
        /// This method selectes if the id is selected or not.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Bool.</returns>
        public bool Select(int id);

        /// <summary>
        /// This method unselects the id.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Bool.</returns>
        public bool UnSelect(int id);
    }
}
