using System.Windows;
using CakeManagementApp.BL;
using CakeManagementApp.UI;
using CakeShop.Data;
using CakeShop.Repository;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore;

namespace CakeManagementApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// App method created instances
        /// </summary>
        public App()
        {
            ServiceLocator.SetLocatorProvider(() => MyIoc.Instance);
            MyIoc.Instance.Register<IEditorService, EditorServiceViaWindow>();
            MyIoc.Instance.Register<IMessenger>(() => Messenger.Default);
            MyIoc.Instance.Register<IBakerLogicVM, BakerLogic>();
            MyIoc.Instance.Register<IBakerRepository, BakerRepository>();
            MyIoc.Instance.Register<DbContext, CakeDbContext>();

        }

        /// <summary>
        /// The Ioc.
        /// </summary>
        private class MyIoc : SimpleIoc, IServiceLocator
        {
            /// <summary>
            /// Gets ioc instance.
            /// </summary>
            public static MyIoc Instance { get; private set; } = new MyIoc();
        }
    }
}
