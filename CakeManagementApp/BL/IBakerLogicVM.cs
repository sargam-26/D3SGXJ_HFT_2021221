using CakeManagementApp.Data;
using CakeShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeManagementApp.BL
{
    /// <summary>
    /// interface declares methods to perform for Bker table
    /// </summary>
    public interface IBakerLogicVM
    {
        /// <summary>
        /// this method declares editBaker method.
        /// </summary>
        /// <param name="baker">Baker.</param>
        public void EditBaker(BakerVM baker);
        /// <summary>
        /// this method declares Add baker method in a list.
        /// </summary>
        /// <param name="bakerList">bakers.</param>
        public void Add(IList<BakerVM> bakerList);
        /// <summary>
        /// this method declares delete method to del a baker from the list.
        /// </summary>
        /// <param name="bakerList">bakers</param>
        /// <param name="baker">bakers.</param>
        public void Delete(IList<BakerVM> bakerList, BakerVM baker);
        /// <summary>
        /// this method is for getAll bakers list.
        /// </summary>
        /// <returns>All bakers.</returns>
        public IList<BakerVM> GetAllBakers();
    }
}
