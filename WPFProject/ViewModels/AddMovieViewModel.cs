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
        public string ErrorString { get; set; }
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
            this.ErrorString = "";
            this.SubmitCommand = new RelayCommand(Submit);
            this.LoadFormData = new RelayCommand(LoadData);
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
            var result =  AddDbRecordService.AddMovie(MovieName, Description, MovieGenre, MoviePlatform, User, UserRating);
            HandleResult(result);
        }

        private void LoadData()
        {
            using MovieCatalogContext context = new MovieCatalogContext();
            var genres  =  context.Genres.ToList();
            var platforms  =  context.Platforms.ToList();
            var users = context.Users.ToList();
            
            AvaliableUsers = users;
            GenresList = genres;
            PlatformsList = platforms;
          
        }

        private void HandleResult( string result)
        {
            if(!(result == "OK"))
            {
                ErrorString = result;
            } else
            {
                ErrorString = "";
                ButtonContent = "Dodaj Następny";
                MovieName = "";
                User = 1;
                UserRating = 3;
                Description = "";
                MovieGenre = 1;
                MoviePlatform = 1;
            }
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