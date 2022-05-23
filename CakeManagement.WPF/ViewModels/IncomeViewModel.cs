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
    public class IncomeViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<IncomeByBaker> IncomeByBakers { get; set; }

        public static bool IsInDesignerMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public IncomeViewModel()
        {
            if(!IsInDesignerMode)
            {
                IncomeByBakers = new RestCollection<IncomeByBaker>("http://localhost:1165/", "baker/income/", "hub");
            }
        }
    }
}
