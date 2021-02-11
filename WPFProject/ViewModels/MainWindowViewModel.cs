using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WPFProject.Base;
using WPFProject.Commands;

namespace WPFProject.ViewModels
{
    public class MainWindowVievModel : BaseViewModel
    {
        /// <summary>
        ///     Selected view that is currently displayed under navigation bar
        /// </summary>
        public BaseViewModel SelectedViewModel { get; set; }

        /// <summary>
        ///     UpdateViewCommand to update view selected by the user. UpdateViewCommand implements ICommand
        /// </summary>
        public ICommand UpdateViewCommand { get; set; }

        /// <summary>
        ///     Constructor that sets current view which is main window at the start of the application
        /// </summary>
        public MainWindowVievModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
        }
    }
}
