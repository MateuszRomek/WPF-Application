using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WPFProject.Base;
using WPFProject.Commands;
using WPFProject.DB.Data;
using WPFProject.DB.Models;

namespace WPFProject.ViewModels
{
    public class AddListViewModel : BaseViewModel, IDataErrorInfo
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

        public AddListViewModel()
        {
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
          

            //Trace.WriteLine(MovieGenre);
            //Trace.WriteLine(UserRating);
            //Trace.WriteLine(MoviePlatform);
            //Trace.WriteLine(MovieName);
            //Trace.WriteLine(User);
            //CREATE Obj in db

           

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


                    Trace.WriteLine($"{MovieGenre}, MovieGenre");
                    Trace.WriteLine($"{genre.GenreName}, MovieGenre");
                    Trace.WriteLine($"{User}, User");
                    Trace.WriteLine($"{user.UserName}, User");
                    Trace.WriteLine($"{MoviePlatform}, Platform");
                    Trace.WriteLine($"{platform.PlatformName}, Platform");
                    Trace.WriteLine($"{UserRating}, Rating");
                    Trace.WriteLine($"{rating.RatingName}, Rating");


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