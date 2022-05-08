using CakeShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Logic
{
    /// <summary>
    /// IEditorService interface.
    /// </summary>
    public interface IEditorService
    {
        /// <summary>
        /// EditBaker method.
        /// </summary>
        /// <param name="baker">Baker.</param>
        /// <returns>bool.</returns>
        bool EditBaker(Baker baker);
    }
}
