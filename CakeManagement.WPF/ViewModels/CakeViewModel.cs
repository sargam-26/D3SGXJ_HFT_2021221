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
    public class CakeViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Cake> Cakes { get; set; }

        public ICommand CreateCakeButton { get; set; }
        public ICommand EditCakeButton { get; set; }
        public ICommand DeleteCakeButton { get; set; }

        public RelayCommand CakeDeliveryButton { get; set; }

        private Cake selectedCake;

        public Cake SelectedCake
        {
            get { return selectedCake; }
            set
            {
                if (value != null)
                {
                    selectedCake = new Cake()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Shape = value.Shape,
                        Color = value.Color,
                        DeliveryId = value.DeliveryId,
                        BakerId = value.BakerId,
                        Price = value.Price,
                        Baker = value.Baker,
                        Delivery = value.Delivery,
                    };
                    OnPropertyChanged();
                    (DeleteCakeButton as RelayCommand).NotifyCanExecuteChanged();
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

        public CakeViewModel()
        {
            if (!IsInDesignerMode)
            {
                Cakes = new RestCollection<Cake>("http://localhost:1165/", "cake", "hub");

                CreateCakeButton = new RelayCommand(() =>
                {
                    Cakes.Add(new Cake()
                    {
                        Name = selectedCake.Name,
                        Shape = selectedCake.Shape,
                        Color = selectedCake.Color,
                        Price = selectedCake.Price,
                        BakerId = selectedCake.BakerId,
                        DeliveryId = selectedCake.DeliveryId,
                    });
                });

                EditCakeButton = new RelayCommand(() =>
                {
                    try
                    {
                        Cakes.Update(SelectedCake);
                        //    UpdateNonCrud();
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteCakeButton = new RelayCommand(() =>
                {
                    Cakes.Delete(SelectedCake.Id);
                    // UpdateNonCrud();
                },
                () =>
                {
                    return SelectedCake != null;
                });
                CakeDeliveryButton = new RelayCommand(InitializeCakeDeliveryWindow);

                SelectedCake = new Cake();
            }
        }
        private void InitializeCakeDeliveryWindow()
        {
            new CakeDeliveryWindow().Show();
        }
    }
}
