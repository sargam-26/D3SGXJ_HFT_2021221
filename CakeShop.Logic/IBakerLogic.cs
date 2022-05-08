using CakeShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Logic
{
    /// <summary>
    /// This is IBakerLogic interface with methods.
    /// </summary>
    public interface IBakerLogic
    {
        /// <summary>
        /// EditBaker method.
        /// </summary>
        /// <param name="baker">Baker.</param>
        public void EditBaker(Baker baker);
        /// <summary>
        /// Adds list of bakers.
        /// </summary>
        /// <param name="bakerList">Bakers.</param>
        public void Add(IList<Baker> bakerList);
        /// <summary>
        /// Deletes Baker.
        /// </summary>
        /// <param name="bakerList">Baker obj.</param>
        /// <param name="baker">Baker.</param>
        public void Delete(IList<Baker> bakerList, Baker baker);
        /// <summary>
        /// This method Gets All Bakers.
        /// </summary>
        /// <returns>List.</returns>
        public IList<Baker> GetAllBakers();
    }
}
