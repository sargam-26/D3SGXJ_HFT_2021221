using CakeManagementApp.Data;
using CakeManagementApp.VM;
using CakeShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CakeManagementApp.UI
{
    /// <summary>
    /// Interaction logic for EditorWindow.xaml
    /// </summary>
    public partial class EditorWindow : Window
    {
        private readonly EditorViewModel editorViewModel;
        /// <summary>
        /// Gets baker editorViewModel
        /// </summary>
        public BakerVM Baker { get => editorViewModel.Baker; }
        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindow"/> class.
        /// Constructor
        /// </summary>
        public EditorWindow()
        {
            InitializeComponent();
            editorViewModel = FindResource("VM") as EditorViewModel;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindow"/> class.
        /// Constructor, Initializes  baker editorViewModel as oldbaker.
        /// </summary>
        /// <param name="oldBaker">baker.</param>
        public EditorWindow(BakerVM oldBaker) : this()
        {
            editorViewModel.Baker = oldBaker;
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelCLick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
