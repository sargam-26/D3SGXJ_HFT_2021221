using CakeManagementApp.Data;
using CakeShop.Data;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeManagementApp.VM
{
    /// <summary>
    /// edits the baker info.
    /// </summary>
    public class EditorViewModel : ViewModelBase
    {
        private BakerVM baker;
        /// <summary>
        /// Gets or sets and sets the baker
        /// </summary>
        public BakerVM Baker
        {
            get { return baker; }
            set { Set(ref baker, value); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorViewModel"/> class.
        /// constructor instantiates the baker fields.
        /// </summary>
        public EditorViewModel()
        {
            baker = new BakerVM();
            if (IsInDesignMode)
            {
                baker.Name = "Sargam";
                baker.Salary = 20000;
                baker.Position = "Head";
                baker.WorkHours = 8;
            }
        }

    }
}
