using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFProjekt.Commands;
namespace WPFProjekt.ViewModels
{
    public class MainViewModel : BaseViewModel
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
        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
        }
    }
}
