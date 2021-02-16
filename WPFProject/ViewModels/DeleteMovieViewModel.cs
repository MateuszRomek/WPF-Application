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
        /// <summary>
        ///  Action that is executed when user click Delete button
        /// </summary>
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// The name of the movie to be deleted.
        /// </summary>
        public string DeleteMovieTitle { get; set; }
        /// <summary>
        /// Error Message to inform user what went wrong.
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// Delete Button content
        /// </summary>
        public string ButtonContent { get; set; }

        /// <summary>
        /// DeleteViewModal Initialization
        /// </summary>
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
                ErrorMessage = result;

            } else
            {
                ErrorMessage = "";
                DeleteMovieTitle = "";
                ButtonContent = "Usuń Następny";
            }
        }

    }
}
