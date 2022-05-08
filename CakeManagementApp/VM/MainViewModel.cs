using CakeManagementApp.BL;
using CakeManagementApp.Data;
using CakeShop.Data;
using CakeShop.Logic;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CakeManagementApp.VM
{
    /// <summary>
    /// this class get and set field and methods
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private IBakerLogicVM logic;
        private BakerVM bakerSelected;
        /// <summary>
        /// Gets or sets gte and set prop for selecting baker
        /// </summary>
        public BakerVM BakerSelected { get => bakerSelected; set => Set(ref bakerSelected, value); }
        /// <summary>
        /// gets baker vm.
        /// </summary>
        public ObservableCollection<BakerVM> Bakers { get; private set; }
        /// <summary>
        /// gets int of command
        /// </summary>
        public ICommand AddCommand
        {
            get; private set;
        }

        /// <summary>
        /// gets deleted command prop
        /// </summary>
        public ICommand DeleteCommand { get; private set; }

        /// <summary>
        /// gets modify command prop
        /// </summary>
        public ICommand ModifyCommand { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// const with logic of baker to add, modify and delete bakers.
        /// </summary>
        /// <param name="logic">Ibkaer obj.</param>
        public MainViewModel(IBakerLogicVM logic)
        {
            this.logic = logic;
            Bakers = new ObservableCollection<BakerVM>();
            if (IsInDesignMode)
            {
                BakerVM baker = new BakerVM() { Name = "Ron" };
                BakerVM baker1 = new BakerVM() { Name = "Kevin" };
                Bakers.Add(baker);
                Bakers.Add(baker1);
            }
            else
            {
                IList<BakerVM> lists = this.logic.GetAllBakers();
                foreach (var item in lists)
                {
                    this.Bakers.Add(item);
                }
            }

            AddCommand = new RelayCommand(() => this.logic.Add(this.Bakers));
            DeleteCommand = new RelayCommand(() => this.logic.Delete(this.Bakers, this.BakerSelected));
            ModifyCommand = new RelayCommand(() => this.logic.EditBaker(this.BakerSelected));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// const initialized
        /// </summary>
        public MainViewModel()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IBakerLogicVM>())
        {

        }

    }
}
