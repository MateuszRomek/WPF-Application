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
    
        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

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
