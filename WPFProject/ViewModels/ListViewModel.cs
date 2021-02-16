using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WPFProject.Base;
using WPFProject.Commands;
using WPFProject.DB.Data;

namespace WPFProject.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        /// <summary>
        /// List of movies in the database.
        /// </summary>
        public List<ListViewObject> Movies { get; set; }

        /// <summary>
        /// Command that executes when View is loaded.
        /// </summary>
        public ICommand LoadData { get; set; }

        /// <summary>
        /// ListViewModal initialization
        /// </summary>
        public ListViewModel()
        {
            this.LoadData = new RelayCommand(LoadMovies);
        }


        private void LoadMovies()
        {
            try
            {
                using (MovieCatalogContext context = new MovieCatalogContext())
                {
                    var movies = context.Movies.Join(context.Platforms,
                                                movie => movie.Platform.Id,
                                                platform => platform.Id,
                                                (movie, platform) => new
                                                {
                                                    MovieId = movie.Id,
                                                    PlatformName = platform.PlatformName,
                                                    MovieTitle = movie.Title,
                                                    MovieRating = movie.Rating,
                                                    MovieGenre = movie.Genre
                                                })
                                            .Join(context.Genres,
                                                   movie => movie.MovieGenre.Id,
                                                   genre => genre.Id,
                                                   (movie, genre) => new
                                                   {
                                                       MovieId = movie.MovieId,
                                                       PlatformName = movie.PlatformName,
                                                       MovieTitle = movie.MovieTitle,
                                                       MovieRating = movie.MovieRating,
                                                       MovieGenre = genre.GenreName
                                                   }
                                                  )
                                            .Join(context.Ratings,
                                                  movie => movie.MovieRating.Id,
                                                  rating => rating.Id,
                                                  (movie, rating) => new
                                                  {
                                                      MovieId = movie.MovieId,
                                                      PlatformName = movie.PlatformName,
                                                      MovieTitle = movie.MovieTitle,
                                                      MovieRating = rating.Id,
                                                      MovieGenre = movie.MovieGenre,
                                                  }
                                            )
                                            .Join(context.Users,
                                                  movie => movie.MovieId,
                                                  user => user.Id,
                                                  (movie, user) => new ListViewObject(movie.MovieId, movie.PlatformName, movie.MovieTitle, movie.MovieRating, movie.MovieGenre, user.UserName)
                                            )
                                            .ToList();

                    Movies = movies;
                }
            } catch(Exception e)
            {
                throw new Exception(e.Message);
            }

           
        }

    }
    
}
