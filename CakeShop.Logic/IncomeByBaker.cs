namespace CakeShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class contains the datafields of the baker.
    /// </summary>
    public class IncomeByBaker
    {
        /// <summary>
        /// gets or sets the bakername.
        /// </summary>
        public string BakerName { get; set; }

        /// <summary>
        /// gets or sets the baker income.
        /// </summary>
        public int Income { get; set; }

        /// <summary>
        /// converts the class into the string.
        /// </summary>
        /// <returns>sting.</returns>
        public override string ToString()
        {
            return $"Baker's Name: {this.BakerName}, Total Income: {this.Income}";
        }

        /// <summary>
        /// this method override the equals method.
        /// </summary>
        /// <param name="obj">object.</param>
        /// <returns>bool.</returns>
        public override bool Equals(object obj)
        {
            if (obj is IncomeByBaker)
            {
                IncomeByBaker other = obj as IncomeByBaker;
                return this.BakerName == other.BakerName && this.Income == other.Income;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// this method overrides the gethashcode.
        /// </summary>
        /// <returns>bool.</returns>
        public override int GetHashCode()
        {
            return this.BakerName.GetHashCode() + this.Income;
        }
    }
}
