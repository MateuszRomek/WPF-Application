using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFProjekt.ViewModels;

namespace WPFProjekt.Commands
{
    public class UpdateViewCommand : ICommand
    {

        private MainViewModel viewModel;

        public event EventHandler CanExecuteChanged;
    
        /// <summary>
        /// Constructor that takes view model to set private field
        /// </summary>
        /// <param name="viewModel"></param>
        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        /// <summary>
        /// Method that always return true. Always change view
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        ///  Method that takes parameter and based on that decide which model view should be created
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            if (parameter.ToString() == "List")
            {
                viewModel.SelectedViewModel = new ListViewModel();
            } else if(parameter.ToString() == "EditList")
            {
                viewModel.SelectedViewModel = new EditViewModel();
            }
           
        }
    }
}
