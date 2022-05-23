using CakeShop.Data;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
namespace CakeManagement.WPF.ViewModels
{
    public class BakerViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage ,value); }
        }

        public RestCollection<Baker> Bakers { get; set; }

        public ICommand CreateBakerButton { get; set; }
        public ICommand EditBakerButton { get; set; }
        public ICommand DeleteBakerButton { get; set; }

        public RelayCommand AveragePriceButton { get; set; }

        public RelayCommand IncomeButton { get; set; }

        private Baker selectedBaker;

        public Baker SelectedBaker
        {
            get { return selectedBaker; }
            set
            {
                if (value != null)
                {
                    selectedBaker = new Baker()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Salary = value.Salary,
                        Position = value.Position,
                        Workhours = value.Workhours,
                    };
                    OnPropertyChanged();
                    (DeleteBakerButton as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public static bool IsInDesignerMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public BakerViewModel()
        {
            if(!IsInDesignerMode)
            {
                Bakers = new RestCollection<Baker>("http://localhost:1165/", "baker", "hub");

                CreateBakerButton = new RelayCommand(() =>
                {
                    Bakers.Add(new Baker()
                    {
                        Name = selectedBaker.Name,
                        Position = selectedBaker.Position,
                        Salary = selectedBaker.Salary,
                        Workhours = selectedBaker.Workhours,
                    });
                });

                EditBakerButton = new RelayCommand(() =>
                {
                    try
                    {
                        Bakers.Update(SelectedBaker);
                        //    UpdateNonCrud();
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteBakerButton = new RelayCommand(() =>
                {
                    Bakers.Delete(SelectedBaker.Id);
                    // UpdateNonCrud();
                },
                () =>
                {
                    return SelectedBaker != null;
                });

                AveragePriceButton = new RelayCommand(InitializeAverageWindow);
                IncomeButton = new RelayCommand(InitializeIncomeWindow);

                SelectedBaker = new Baker();
            }
        }

        private void InitializeAverageWindow()
        {
            new AverageWindow().Show();
        }

        private void InitializeIncomeWindow()
        {
            new IncomeWindow().Show();
        }
    }
}
