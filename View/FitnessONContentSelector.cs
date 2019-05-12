using FitnessON.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FitnessON.View
{
    public class FitnessONContentSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if(item is ILoginContent)
            {
                return Application.Current.MainWindow.TryFindResource("LoginTemplate") as DataTemplate;
            }
            else if (item is IProfileContent)
            {
                return Application.Current.MainWindow.TryFindResource("ProfileTemplate") as DataTemplate;
            }
            else if (item is IListUserLeasesContent)
            {
                return Application.Current.MainWindow.TryFindResource("ListUserLeasesTemplate") as DataTemplate;
            }
            else if (item is IAdminProfileContent)
            {
                return Application.Current.MainWindow.TryFindResource("AdminProfileTemplate") as DataTemplate;
            }
            else if (item is IEntriesListingWithFilterContent)
            {
                return Application.Current.MainWindow.TryFindResource("EntriesListingWithFilterTemplate") as DataTemplate;
            }
            else if (item is ILeaseListingWithFilterContent)
            {
                return Application.Current.MainWindow.TryFindResource("LeaseListingWithFilterTemplate") as DataTemplate;
            }
            return null;
        }
    }
}
