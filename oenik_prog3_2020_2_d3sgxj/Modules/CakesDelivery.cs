namespace CakeShop.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CakeShop.Data;

    /// <summary>
    /// This shows the datafield of the cakes delivery from database.
    /// </summary>
    public class CakesDelivery
    {
        /// <summary>
        /// gets or sets the person name.
        /// </summary>
        public string Person { get; set; }

        /// <summary>
        /// Gets or sets the cake name.
        /// </summary>
        public List<Cake> Cakes { get; set; }

        /// <summary>
        /// This method overrides the equals methd.
        /// </summary>
        /// <param name="obj">object.</param>
        /// <returns>bool.</returns>
        public override bool Equals(object obj)
        {
            if (obj is CakesDelivery)
            {
                CakesDelivery other = obj as CakesDelivery;
                return this.Person == other.Person && this.Cakes == other.Cakes;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// this method overrides the hashcode.
        /// </summary>
        /// <returns>int.</returns>
        public override int GetHashCode()
        {
            return this.Person.GetHashCode();
        }

        /// <summary>
        /// This method converts the class into string.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString()
        {
            string myString = this.Person + "\n";

            foreach (Cake cake in this.Cakes)
            {
                myString += cake;
            }

            return myString;
        }
    }
}
