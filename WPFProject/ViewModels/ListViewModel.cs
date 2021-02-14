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
        public List<ListViewObject> Movies { get; set; }
        public ICommand LoadData { get; set; }
        public ListViewModel()
        {
            this.LoadData = new RelayCommand(LoadMovies);
        }


        private void LoadMovies()
        {
            using MovieCatalogContext context = new MovieCatalogContext();
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
                                         .Join( context.Genres,
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
                                               (movie, rating) => new ListViewObject(movie.MovieId, movie.PlatformName, movie.MovieTitle, rating.RatingValue, movie.MovieGenre)
                                         ).ToList();

            Movies = movies;
        }

    }

    public struct ListViewObject
    {
        public int MovieId { get; private set; }
        public string PlatformName { get;  private set; }
        public string MovieTitle { get; private set; }
        public int MovieRating { get; private set; }

        public string MovieGenre { get; private set; }

        public ListViewObject(int id,  string pName, string mTitle, int mRating, string mGenre )
        {
            MovieId = id;
            PlatformName = pName;
            MovieTitle = mTitle;
            MovieRating = mRating;
            MovieGenre = mGenre;
        }
    }
}
