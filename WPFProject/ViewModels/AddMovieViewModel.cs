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

namespace WPFProject.ViewModels
{
    public class AddMovieViewModel : BaseViewModel, IDataErrorInfo
    {
        public ICommand SubmitCommand { get; set; }
        public ICommand LoadFormData { get; set; }
        public string Description { get; set; }
        public string MovieName { get; set; }
        public int UserRating { get; set; }
        public int User { get; set; }
        public int MoviePlatform { get; set; }
        public bool IsEnabled { get; set; }
        public int MovieGenre { get; set; }

        public string ButtonContent { get; set; } = "Dodaj";

        public ObservableCollection<RatingElement> RatingList { get;set; }

        public List<DB.Models.Genre> GenresList { get; set; }
        public List<DB.Models.Platform> PlatformsList { get; set; }

        public List<DB.Models.User> AvaliableUsers { get; set; }

        public string Error
        {
            get { return string.Empty; }
        }

        public string this[string columnName] 
        {
            get
            {
                if ("Description" == columnName && String.IsNullOrEmpty(Description) ||  "MovieName" == columnName && String.IsNullOrEmpty(MovieName))
                {
                        IsEnabled = false;
                        return "Enter Movie Name";   
                } else
                {
                    if(!String.IsNullOrEmpty(Description) && !String.IsNullOrEmpty(MovieName))
                    {
                        IsEnabled = true;
                    }
                    return "";
                }
            }
        }

        public AddMovieViewModel()
        {
            this.ButtonContent = "Dodaj";
            this.SubmitCommand = new RelayCommand(Submit);
            this.LoadFormData = new RelayCommand(LoadDataAsync);
            this.RatingList = new ObservableCollection<RatingElement>()
        {
            new RatingElement("Nieporozumienie", 1),
            new RatingElement("Ujdzie", 2),
            new RatingElement("Średni", 3),
            new RatingElement("Dobry", 4),
            new RatingElement("Świetny", 5),
        };
        }

        private void Submit()
        {
          
            try
            {

                using (MovieCatalogContext context = new MovieCatalogContext())
                {

                    var genre = context.Genres
                        .Where(g => g.Id == MovieGenre)
                        .FirstOrDefault();

                    var user = context.Users
                        .Where(u => u.Id == User)
                        .FirstOrDefault();


                    var platform = context.Platforms
                        .Where(g => g.Id == MoviePlatform)
                        .FirstOrDefault();

                    var rating = context.Ratings
                         .Where(r => r.Id == UserRating)
                         .FirstOrDefault();

                    Movie movie = new Movie()
                    {
                        Description = Description,
                        Title = MovieName,
                        Genre = genre,
                        Platform = platform,
                        Rating = rating
                    };

                    if (movie.Users == null)
                    {
                        movie.Users = new List<User>();
                    }

                    movie.Users.Add(user);

                    context.Movies.Add(movie);

                    context.SaveChanges();

                    ButtonContent = "Dodaj Następny";
                    MovieName = "";
                    User = 1;
                    UserRating = 3;
                    Description = "";
                    MovieGenre = 1;
                    MoviePlatform = 1;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException();
            }


        }

        private  void LoadDataAsync()
        {
            using MovieCatalogContext context = new MovieCatalogContext();
            var genres  =  context.Genres.ToList();
            var platforms  =  context.Platforms.ToList();
            var users = context.Users.ToList();
            
            AvaliableUsers = users;
            GenresList = genres;
            PlatformsList = platforms;
          
        }


    }
}

public class RatingElement
{
    public int Id { get; set; }
    public string RatingName { get; set; }
    public RatingElement(string name, int id)
    {
        RatingName = name;
        Id = id;
    }

}