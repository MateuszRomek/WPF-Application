using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using WPFProject.Base;
using WPFProject.Commands;

namespace WPFProject.ViewModels
{
    public class AddListViewModel : BaseViewModel
    {
        public ICommand SubmitCommand { get; set; }

        public string MovieName { get; set; }

        public string UserRating { get; set; }

        public string MoviePlatform { get; set; }

        public string MovieGenre { get; set; }

        public AddListViewModel()
        {
            this.SubmitCommand = new RelayCommand(Submit);
        }

        private void Submit()
        {
          

            Trace.WriteLine(MovieGenre);
            Trace.WriteLine(UserRating);
            Trace.WriteLine(MoviePlatform);
            Trace.WriteLine(MovieName);
          //CREATE Obj in db
        }
    }
}
