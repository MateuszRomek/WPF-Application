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
    public class WishlistViewModel : BaseViewModel
    {
        public ICommand AddAction { get; set; }
        public ICommand DeleteAction { get; set; }

        public ICommand LoadData { get; set; }
        public string ErrorMessage { get; set; }
        public string MovieTitle { get; set; }

        public List<string> Wishlist { get; set;}

        public WishlistViewModel()
        {
            this.AddAction = new RelayCommand(AddMovieToWishlist);
            this.DeleteAction = new RelayCommand(RemoveMovieFromWishlist);
            this.LoadData = new RelayCommand(LoadWishlist);
        }

        private void AddMovieToWishlist() 
        {
            var result = AddDbRecordService.AddMovieToWishlist(MovieTitle);
            HandleResult(result);
            LoadWishlist();
        }

        private void RemoveMovieFromWishlist() 
        {
            var result = DeleteDbRecordService.DeleteWishlistItem(MovieTitle);
            HandleResult(result);
            LoadWishlist();

        }

        private void HandleResult(string result) { 
            MovieTitle = "";
            if( result != "OK")
            {
                ErrorMessage = result;
            } else
            {
                ErrorMessage = "";
            }
        }

        private void LoadWishlist()
        {
            try
            {
                using(var  context = new MovieCatalogContext())
                {
                    var wishlist = context.Wishlist.Select(w => w.MovieTitle).ToList();
                    Wishlist = wishlist;
                }

            } catch (Exception e )
            {
                throw new Exception(e.Message);
            }
        }
    }
}
