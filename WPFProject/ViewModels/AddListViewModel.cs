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

namespace WPFProject.ViewModels
{
    public class AddListViewModel : BaseViewModel, IDataErrorInfo
    {
        public ICommand SubmitCommand { get; set; }
        public ICommand LoadFormData { get; set; }

        public string MovieName { get; set; }

        public int UserRating { get; set; }

        public int MoviePlatform { get; set; }
        public bool IsEnabled { get; set; }
        public int MovieGenre { get; set; }


        public ObservableCollection<RatingElement> RatingList { get;set; }

        public List<DB.Models.Genre> GenresList { get; set; }
        public List<DB.Models.Platform> PlatformsList { get; set; }

        public string Error => throw new NotImplementedException();

        public string this[string columnName] 
        {
            get
            {
                if ("MovieName" == columnName && String.IsNullOrEmpty(MovieName))
                {
                        IsEnabled = false;
                        return "Enter Movie Name";   
                } else
                {
                    IsEnabled = true;
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
          

            Trace.WriteLine(MovieGenre);
            Trace.WriteLine(UserRating);
            Trace.WriteLine(MoviePlatform);
            Trace.WriteLine(MovieName);
      
            //CREATE Obj in db


        }

        private  void LoadDataAsync()
        {
            using MovieCatalogContext context = new MovieCatalogContext();
            var g  =  context.Genres.ToList();
            var p  =  context.Platforms.ToList();

            GenresList = g;
            PlatformsList = p;
          
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