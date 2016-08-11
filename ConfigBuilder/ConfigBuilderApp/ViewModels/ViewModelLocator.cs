using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConfigBuilderApp.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(()=>SimpleIoc.Default);
            SimpleIoc.Default.Register<MainWindowViewModel>();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMethod);
        }

        public MainWindowViewModel MainWindowViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainWindowViewModel>();
            }
        }

        private void NotificationMethod(NotificationMessage msg)
        {
            MessageBox.Show(msg.Notification);
        }
    }
}
