using FitnessON.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FitnessON.Common
{
    public class ViewService
    {
        private static Dictionary<Type, Type> registeredViews;

        /// <summary>
        /// The opened windows
        /// </summary>
        private static Dictionary<NotificationClass, Window> openedWindows;

        /// <summary>
        /// Initializes the <see cref="ViewService"/> class.
        /// </summary>
        static ViewService()
        {
            registeredViews = new Dictionary<Type, Type>();
            openedWindows = new Dictionary<NotificationClass, Window>();
        }

        /// <summary>
        /// Registers the view.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="window">The window.</param>
        public static void RegisterView(Type viewModel, Type window)
        {
            registeredViews[viewModel] = window;
        }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="parent">The parent.</param>
        public static void ShowDialog(NotificationClass viewModel, NotificationClass parent = null)
        {
            Type windowType;

            if (registeredViews.TryGetValue(viewModel.GetType(), out windowType))
            {
                Window window = Activator.CreateInstance(windowType) as Window;

                if (window != null)
                {
                    window.DataContext = viewModel;

                    openedWindows[viewModel] = window;

                    if (parent != null)
                    {
                        Window parentWindow;
                        if (openedWindows.TryGetValue(parent, out parentWindow))
                        {
                            window.Owner = parentWindow;
                        }
                    }

                    window.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Closes the dialog.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public static void CloseDialog(NotificationClass viewModel)
        {
            Window windowToClose;

            if (openedWindows.TryGetValue(viewModel, out windowToClose))
            {
                windowToClose.Close();
                openedWindows.Remove(viewModel);
            }
        }

        /// <summary>
        /// Adds the main window to opened.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="window">The window.</param>
        public static void AddMainWindowToOpened(NotificationClass viewModel, Window window)
        {
            if (viewModel != null && window != null)
            {
                openedWindows[viewModel] = window;
            }
        }
    }
}
