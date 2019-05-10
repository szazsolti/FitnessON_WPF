using FitnessON.Infra;
using FitnessON.ViewModel;
using FitnessON.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitnessON
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Closed += MainWindow_Closed;
            /* (this.DataContext as MainWindowViewModel).ShowMessageBox += delegate (object sender, EventArgs args)
             {
                 MessageBox.Show(((MessageEventArgs)args).Message);
             };*/
        }
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
