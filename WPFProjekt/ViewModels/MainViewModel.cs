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
        public BaseViewModel SelectedViewModel { get; set; }

        public ICommand UpdateViewCommand { get; set; }

        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
        }
    }
}
