using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WPFProject.Base;
using WPFProject.Commands;

namespace WPFProject.ViewModels
{
    public class AddListViewModel : BaseViewModel
    {
        public ICommand SubmitCommand { get; set; }

        public string MovieName { get; set; } = "Test";

        public AddListViewModel()
        {
            this.SubmitCommand = new RelayCommand(Submit);
        }

        private void Submit()
        {
            Console.WriteLine(MovieName);
        }
    }
}
