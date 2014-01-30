using System.Globalization;
using System.Windows;
using System.Windows.Markup;
using Ciklum.WpfApplication.ViewModel;
using System;

namespace Ciklum.WpfApplication
{
    public partial class App : Application
    {
        static App()
        {
            FrameworkElement.LanguageProperty.OverrideMetadata(
              typeof(FrameworkElement),
              new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            string souceFilePath = "Source/Contacts.xml";
            EventHandler handler = null;

            var window = new MainWindow();
            var viewModel = new MainWindowViewModel(souceFilePath);
            
            handler = delegate
            {
                viewModel.RequestClose -= handler;
                window.Close();
            };

            viewModel.RequestClose += handler;

            window.DataContext = viewModel;

            window.Show();
        }
    }
}