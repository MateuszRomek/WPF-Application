using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFProjekt.ViewModels
{

    /// <summary>
    ///    BaseViewModel from which other ViewModels will inherit
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        ///    Method that will update view model
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
