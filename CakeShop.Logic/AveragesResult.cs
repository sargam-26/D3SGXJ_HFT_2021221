namespace CakeShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class shows the datafield of the avergae.
    /// </summary>
    public class AveragesResult
    {
        /// <summary>
        /// gets or sets the baker name.
        /// </summary>
        public string BakerName { get; set; }

        /// <summary>
        /// gets or sets the average price.
        /// </summary>
        public double AveragePrice { get; set; }

        /// <summary>
        /// This methods converts the class into string.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString()
        {
            return $"Baker's Name ={this.BakerName}; Average Cake Price={this.AveragePrice}";
        }

        /// <summary>
        /// This method override the equals.
        /// </summary>
        /// <param name="obj">object.</param>
        /// <returns>bool.</returns>
        public override bool Equals(object obj)
        {
            if (obj is AveragesResult)
            {
                AveragesResult other = obj as AveragesResult;
                return this.BakerName == other.BakerName && this.AveragePrice == other.AveragePrice;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This method oveerides the hashcode.
        /// </summary>
        /// <returns>int.</returns>
        public override int GetHashCode()
        {
            return (int)this.AveragePrice + this.BakerName.GetHashCode();
        }
    }
}
