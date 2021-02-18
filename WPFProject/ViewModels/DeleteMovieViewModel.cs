using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WPFProject.Base;
using WPFProject.Commands;
using WPFProject.DB.Data;
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
        /// The command that is executed when view is loaded.
        /// </summary>
        public ICommand LoadData { get; set; }

        /// <summary>
        /// User that added movie. This value is set by default (in View) to Anonymous user
        /// </summary>
        public int User { get; set; }

        /// <summary>
        /// This list represents the Users that are defined in the database. It is filled when the view loads.
        /// </summary>

        public List<DB.Models.User> AvaliableUsers { get; set; }

        /// <summary>
        /// DeleteViewModal Initialization
        /// </summary>
        public DeleteMovieViewModel()
        {
            this.DeleteCommand = new RelayCommand(DeleteMovie);
            this.ButtonContent = "Usuń";
            this.LoadData = new RelayCommand(LoadDeleteMovie);
        }

        private void DeleteMovie()
        {
            var result = DeleteDbRecordService.DeleteMovie(DeleteMovieTitle, User);
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

        private void LoadDeleteMovie()
        {
            try
            {
                using (var context = new MovieCatalogContext())
                {
                    var users = context.Users.ToList();
                    AvaliableUsers = users;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
