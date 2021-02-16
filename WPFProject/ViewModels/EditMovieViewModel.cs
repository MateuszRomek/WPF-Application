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

        public string  SearchMovieTitle {get;set;}
        public string Description { get; set; }
        public string MovieName { get; set; }
        public int UserRating { get; set; }
        public int MoviePlatform { get; set; }
        public int MovieGenre { get; set; }
        public string ErrorMessage { get; set; }
        public int SelectedMoviePlatform { get; set; }
        public int SelectedMovieGenre { get; set; }
        public int SelectedMovieRating { get; set; }

        public string VisibleForm { get; set; }
        public ObservableCollection<RatingElement> RatingList { get; set; }

        public List<DB.Models.Genre> GenresList { get; set; }
        public List<DB.Models.Platform> PlatformsList { get; set; }

        public ICommand SaveAction { get; set; }
        public ICommand SearchAction { get; set; }

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

                    GenresList = genres;
                    PlatformsList = platforms;

                    this.RatingList = new ObservableCollection<RatingElement>()
                {
                    new RatingElement("Nieporozumienie", 1),
                    new RatingElement("Ujdzie", 2),
                    new RatingElement("Średni", 3),
                    new RatingElement("Dobry", 4),
                    new RatingElement("Świetny", 5),
                };

                    MovieName = movie.Title;
                    Description = movie.Description;
                    SelectedMovieGenre = movie.Genre.Id - 1;
                    SelectedMoviePlatform = movie.Platform.Id - 1;
                    SelectedMovieRating = movie.Rating.Id - 1;
                    VisibleForm = FormVisibility.Visible.ToString();
                }
            } catch ( Exception e )
            {
                throw new Exception(e.Message);
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
                throw new Exception(e.Message);
            }
        }

    }
}
