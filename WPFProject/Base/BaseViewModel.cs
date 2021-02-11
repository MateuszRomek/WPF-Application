using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WPFProject.Base
{
    /// <summary>
    ///    BaseViewModel from which other ViewModels will inherit
    /// </summary>
    /// 
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        ///    Method that will update view model
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
