﻿using FitnessON.Common;
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
            return null;
        }
    }
}