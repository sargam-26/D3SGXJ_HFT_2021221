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
    /// Editor service.
    /// </summary>
    public interface IEditorService
    {
        /// <summary>
        /// Edit baker.
        /// </summary>
        /// <param name="baker">Baker.</param>
        /// <returns>Baker obj.</returns>
        bool EditBaker(BakerVM baker);
    }
}
