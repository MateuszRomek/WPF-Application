using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using WPFProject.Base;
using WPFProject.Commands;
using WPFProject.DB.Data;
using WPFProject.DB.Models;
using WPFProject.Services;

namespace WPFProject.ViewModels
{
    public class AddViewModel : BaseViewModel, IDataErrorInfo
    {
        #region  Commands
        /// <summary>
        ///  Action that is executed when user click Add button
        /// </summary>
        public ICommand SubmitAction { get; set; }
        /// <summary>
        /// Action that is executed when ViewModel is loaded
        /// </summary>
        public ICommand LoadAction { get; set; }
        #endregion

        #region Public Properties
        /// <summary>
        /// Description of the movie. Can be added by the user but it's not required.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// MovieTitle represents title of new movie added by the user. This field is mandatory
        /// </summary>
        public string MovieTitle { get; set; }

        /// <summary>
        /// User rating. This value is set by default (in View) to "Good" rating.
        /// </summary>
        public int UserRating { get; set; }

        /// <summary>
        /// User that added movie. This value is set by default (in View) to Anonymous user
        /// </summary>
        public int User { get; set; }

        /// <summary>
        /// Name of the platform on which the video was viewed. This value is set by default (in View) to Netflix
        /// </summary>
        public int MoviePlatform { get; set; }

        /// <summary>
        /// Name of the movie genre. This value is set by default (in View) to Comedy.
        /// </summary>
        public int MovieGenre { get; set; }
        /// <summary>
        /// This field determines if user can click Add button to create new movie.
        /// The button is enabled when the user completes the MovieTitle field. Otherwise, it is disabled.
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Set button content. If the user adds a couple of movies in a row, it will be set to "Add another"
        /// </summary>
        public string ButtonContent { get; set; } = "Dodaj";
        /// <summary>
        /// Set ErrorMessage for the user if something went wrong.
        /// </summary>
        public string ErrorMessage { get; set; }
        #endregion

        #region Database Lists
        /// <summary>
        /// This list represents the possible Movie Ratings that are defined in the database. It is filled when the view loads.
        /// </summary>
        public List<DB.Models.Rating> RatingList { get; set; }
        /// <summary>
        /// This list represents the possible Movie Genres that are defined in the database. It is filled when the view loads.
        /// </summary>
        public List<DB.Models.Genre> GenresList { get; set; }
        /// <summary>
        /// This list represents the possible Movie Platforms that are defined in the database. It is filled when the view loads.
        /// </summary>
        public List<DB.Models.Platform> PlatformsList { get; set; }
        /// <summary>
        /// This list represents the Users that are defined in the database. It is filled when the view loads.
        /// </summary>

        public List<DB.Models.User> AvaliableUsers { get; set; }
        #endregion
        /// <summary>
        /// Public method that returns empty string. Implemented from IDataErrorInfo interface
        /// </summary>
        public string Error
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// Public method that returns and manages IsEnabled property. 
        /// Implemented from IDataErrorInfo interface.
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string this[string columnName] 
        {
            get
            {
                if ( "MovieTitle" == columnName && String.IsNullOrEmpty(MovieTitle))
                {
                        IsEnabled = false;
                        return "Enter Movie Name";   
                } else
                {
                    if(!String.IsNullOrEmpty(MovieTitle))
                    {
                        IsEnabled = true;
                    }
                    return "";
                }
            }
        }

        /// <summary>
        /// ViewModel Initialization.
        /// </summary>
        public AddViewModel()
        {
            this.ButtonContent = "Dodaj";
            this.ErrorMessage = "";
            this.SubmitAction = new RelayCommand(Submit);
            this.LoadAction = new RelayCommand(LoadData);

        }

        private void Submit()
        {
            var result =  AddDbRecordService.AddMovie(MovieTitle, Description, MovieGenre, MoviePlatform, User, UserRating);
            HandleResult(result);
        }

        private void LoadData()
        {
            using (MovieCatalogContext context = new MovieCatalogContext())
            {

                var genres  =  context.Genres.ToList();
                var platforms  =  context.Platforms.ToList();
                var users = context.Users.ToList();
                var ratings = context.Ratings.ToList();
                AvaliableUsers = users;
                GenresList = genres;
                PlatformsList = platforms;
                RatingList = ratings;
            }
          
        }

        private void HandleResult( string result)
        {
            if(!(result == "OK"))
            {
                ErrorMessage = result;
            } else
            {
                ErrorMessage = "";
                ButtonContent = "Dodaj Następny";
                MovieTitle = "";
                User = 1;
                UserRating = 3;
                Description = "";
                MovieGenre = 1;
                MoviePlatform = 1;
            }
        }
    }
}
