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
    public class AverageViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<AveragesResult> AveragesResults { get; set; }

        public static bool IsInDesignerMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public AverageViewModel()
        {
            if(!IsInDesignerMode)
            {
                AveragesResults = new RestCollection<AveragesResult>("http://localhost:1165/", "baker/average/", "hub");
            }
        }
    }
}
