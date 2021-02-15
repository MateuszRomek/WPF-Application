using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WPFProject.Base;
using WPFProject.Commands;
using WPFProject.Services;

namespace WPFProject.ViewModels
{
    public class DeleteMovieViewModel : BaseViewModel
    {
        public ICommand DeleteCommand { get; set; }
        public string DeleteMovieTitle { get; set; }
        public string ErrorString { get; set; }
        public string ButtonContent { get; set; }
        public DeleteMovieViewModel()
        {
            this.DeleteCommand = new RelayCommand(DeleteMovie);
            this.ButtonContent = "Usuń";
        }

        private void DeleteMovie()
        {
            var result = DeleteDbRecordService.DeleteMovie(DeleteMovieTitle);
            HandleResult(result);
        }

        private void HandleResult(string result)
        {
            if(result != "OK")
            {
                ErrorString = result;

            } else
            {
                ErrorString = "";
                DeleteMovieTitle = "";
                ButtonContent = "Usuń Następny";
            }
        }

    }
}
