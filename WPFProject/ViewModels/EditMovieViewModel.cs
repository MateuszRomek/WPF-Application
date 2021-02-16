using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using WPFProject.Base;
using WPFProject.Commands;
using WPFProject.DB.Data;

namespace WPFProject.ViewModels
{
    public class EditMovieViewModel : BaseViewModel
    {
        #region Public Properties
        /// <summary>
        /// The name of the movie that the user wants to edit
        /// </summary>
        public string  SearchMovieTitle {get;set;}

        /// <summary>
        /// A description of the selected movie that is currently saved in the database. This filed can be modified by the user
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The title of the selected movie, which is currently stored in the database. This field cannot be changed
        /// </summary>
        public string MovieTitle { get; set; }

        /// <summary>
        /// The new UserRating value selected by the user will be assigned to this field.
        /// </summary>
        public int UserRating { get; set; }

        /// <summary>
        /// The new MoviePlatform value selected by the user will be assigned to this field.
        /// </summary>
        public int MoviePlatform { get; set; }

        /// <summary>
        /// The new MovieGenre value selected by the user will be assigned to this field.
        /// </summary>
        public int MovieGenre { get; set; }

        /// <summary>
        /// Error Message to inform user what went wrong or show text about incorrect action
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Platform of the selected movie that is currently saved in the database.
        /// </summary>
        public int SelectedMoviePlatform { get; set; }
        /// <summary>
        /// Genre of the selected movie that is currently saved in the database.
        /// </summary>
        public int SelectedMovieGenre { get; set; }
        /// <summary>
        /// A user rating of the selected movie that is currently saved in the database.
        /// </summary>
        public int SelectedMovieRating { get; set; }
        /// <summary>
        /// The property responsible for whether the form with the movie details is visible.
        /// </summary>
        public string VisibleForm { get; set; }
        #endregion
        #region Database lists
        /// <summary>
        /// List of current ratings extracted from the database.
        /// </summary>
        public List<DB.Models.Rating> RatingList { get; set; }
        /// <summary>
        /// List of current movie genres extracted from the database
        /// </summary>
        public List<DB.Models.Genre> GenresList { get; set; }
        /// <summary>
        /// List of current VOD platforms extracted from the database
        /// </summary>
        public List<DB.Models.Platform> PlatformsList { get; set; }
        #endregion

        #region Commands
        /// <summary>
        /// The Command that is performed after the user presses the Save button 
        /// </summary>
        public ICommand SaveAction { get; set; }
        /// <summary>
        /// The Command that is performed after the user presses the Search button 
        /// </summary>
        public ICommand SearchAction { get; set; }
        #endregion

        /// <summary>
        /// EditMovieViewModel initialization
        /// </summary>
        public EditMovieViewModel()
        {
            this.SaveAction = new RelayCommand(UpdateRecord);
            this.SearchAction = new RelayCommand(FindMovie);
            this.VisibleForm = FormVisibility.Hidden.ToString();
        }


        private void FindMovie()
        {
            ErrorMessage = "";
            try
            {
                using (var context = new MovieCatalogContext())
                {
                    var movie = context.Movies
                        .Include("Rating")
                        .FirstOrDefault(m => m.Title.ToLower().Trim() == SearchMovieTitle.Trim().ToLower());
                    if (movie == null)
                    {
                        ErrorMessage = "Nie ma takiego filmu na Twojej liście";
                        VisibleForm = FormVisibility.Hidden.ToString();
                        return;
                    }


                    var genres = context.Genres.ToList();
                    var platforms = context.Platforms.ToList();
                    var ratings = context.Ratings.ToList();

                    GenresList = genres;
                    PlatformsList = platforms;
                    RatingList = ratings;

                    MovieTitle = movie.Title;
                    Description = movie.Description;
                    SelectedMovieGenre = movie.Genre.Id - 1;
                    SelectedMoviePlatform = movie.Platform.Id - 1;
                    SelectedMovieRating = movie.Rating.Id - 1;
                    VisibleForm = FormVisibility.Visible.ToString();
                }
            } catch ( Exception e )
            {
                ErrorMessage = "An error occurred during the database operation. Please try in a moment.";
            }
        }

        private void UpdateRecord()
        {
            try
            {

                using(var context = new MovieCatalogContext())
                {
                    var movie = context.Movies.SingleOrDefault(m => m.Title.ToLower().Trim() == SearchMovieTitle.ToLower().Trim());


                    var genre = context.Genres
                                .Where(g => g.Id == MovieGenre)
                                .FirstOrDefault();

                    var platform = context.Platforms
                        .Where(g => g.Id == MoviePlatform)
                        .FirstOrDefault();

                    var rating = context.Ratings
                         .Where(r => r.Id == UserRating)
                         .FirstOrDefault();


                    movie.Description = Description;
                    movie.Platform = platform;
                    movie.Genre = genre;
                    movie.Rating = rating;

                    context.SaveChanges();

                    VisibleForm = FormVisibility.Hidden.ToString();
                }

            } catch (Exception e)
            {
                ErrorMessage = "An error occurred during the database operation. Please try in a moment.";
            }
        }

    }
}
