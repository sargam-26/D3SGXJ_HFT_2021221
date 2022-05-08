using CakeManagementApp.BL;
using CakeManagementApp.Data;
using CakeShop.Data;
using CakeShop.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CakeManagementApp.UI
{
    /// <summary>
    /// this class implements the method from IEditorService Interface
    /// </summary>
    public class EditorServiceViaWindow : BL.IEditorService
    {
        /// <summary>
        /// this method edit the baker
        /// </summary>
        /// <param name="baker">baker.</param>
        /// <returns> bool.</returns>
        public bool EditBaker(BakerVM baker)
        {
            EditorWindow win = new EditorWindow(baker);
            return win.ShowDialog() ?? false;
        }
    }
}
