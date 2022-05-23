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
    public class CakeDeliveryViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<CakesDelivery> CakesDeliveries { get; set; }

        public CakesDelivery selectedCakeDelivery { get; set; }

        public CakesDelivery SelectedCakeDelivery
        {
            get { return selectedCakeDelivery; }
            set
            {
                if (value != null)
                {
                    selectedCakeDelivery = new CakesDelivery()
                    {
                        Person = value.Person,
                        Cakes = value.Cakes
                    };              
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

        public CakeDeliveryViewModel()
        {
            if(!IsInDesignerMode)
            {
                CakesDeliveries = new RestCollection<CakesDelivery>("http://localhost:1165/", "cake/cakeDeliveries/", "hub");
            }
        }
    }
}
