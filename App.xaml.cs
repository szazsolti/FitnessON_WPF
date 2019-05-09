using FitnessON.Model.DBContext;
using FitnessON.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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
            //this.Initialize();
            this.InitializeData();
            //this.OpenMainWindow();
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
