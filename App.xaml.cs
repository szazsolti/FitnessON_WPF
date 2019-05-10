using FitnessON.Model.DBContext;
using FitnessON.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FitnessON.ViewModel;
using FitnessON.Common;

namespace FitnessON
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.Initialize();
            this.InitializeData();
            this.OpenMainWindow();
        }

        private void Initialize()
        {
            ViewService.RegisterView(typeof(MainWindowViewModel), typeof(MainWindow));
        }

        private void OpenMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();

            ViewService.AddMainWindowToOpened(mainWindowViewModel, mainWindow);
            ViewService.ShowDialog(mainWindowViewModel);
        }

        private void InitializeData()
        {
            try

            {
                DBInitializer dbinit = new DBInitializer();
                dbinit.InitializeDatabase(new FitnessDB());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
