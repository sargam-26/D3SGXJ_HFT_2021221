using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeManagement.WPF.ViewModels
{
    public class MainViewModel : ObservableRecipient
    {
        public RelayCommand ManageBakersCommand { get; set; }
        public RelayCommand ManageCakesCommand { get; set; }
        public RelayCommand ManageDeliveriesCommand { get; set; }
        public MainViewModel()
        {
            ManageBakersCommand = new RelayCommand(InitializeBakersWindow);
            ManageCakesCommand = new RelayCommand(InitializeCakesWindow);
            ManageDeliveriesCommand = new RelayCommand(InitializeDeliveriesWindow);
        }

        private void InitializeBakersWindow()
        {
            new MainWindow().Show();
        }
        private void InitializeCakesWindow()
        {
            new CakeWindow().Show();
        }
        private void InitializeDeliveriesWindow()
        {
            new DeliveryWindow().Show();

        }
    }
}
