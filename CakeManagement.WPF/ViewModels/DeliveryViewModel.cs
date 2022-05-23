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
    public class DeliveryViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Delivery> Deliveries { get; set; }

        public ICommand CreateDeliveryButton { get; set; }
        public ICommand EditDeliveryButton { get; set; }
        public ICommand DeleteDeliveryButton { get; set; }

        private Delivery selectedDelivery;

        public Delivery SelectedDelivery
        {
            get { return selectedDelivery; }
            set
            {
                if (value != null)
                {
                    selectedDelivery = new Delivery()
                    {
                        Id = value.Id,
                        Person = value.Person,
                        Income = value.Income,
                        Mins = value.Mins,
                        Schedule = value.Schedule,
                    };
                    OnPropertyChanged();
                    (DeleteDeliveryButton as RelayCommand).NotifyCanExecuteChanged();
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

        public DeliveryViewModel()
        {
            if (!IsInDesignerMode)
            {
                Deliveries = new RestCollection<Delivery>("http://localhost:1165/", "delivery", "hub");

                CreateDeliveryButton = new RelayCommand(() =>
                {
                    Deliveries.Add(new Delivery()
                    {
                        Person = selectedDelivery.Person,
                        Mins= selectedDelivery.Mins,
                        Schedule = selectedDelivery.Schedule,
                        Income = selectedDelivery.Income,
                    });
                });

                EditDeliveryButton = new RelayCommand(() =>
                {
                    try
                    {
                        Deliveries.Update(SelectedDelivery);
                        //    UpdateNonCrud();
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteDeliveryButton = new RelayCommand(() =>
                {
                    Deliveries.Delete(SelectedDelivery.Id);
                    // UpdateNonCrud();
                },
                () =>
                {
                    return SelectedDelivery != null;
                });
                SelectedDelivery = new Delivery();
            }
        }
    }

}
