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

        /// <summary>
        /// The command that is executed when the user clicks the Add button
        /// </summary>
        public ICommand AddAction { get; set; }
        /// <summary>
        /// The command that is executed when the user clicks the Delete button
        /// </summary>
        public ICommand DeleteAction { get; set; }
        /// <summary>
        /// The command that is executed when view is loaded.
        /// </summary>
        public ICommand LoadData { get; set; }
        /// <summary>
        /// Error Message to inform user about error or incorrect action
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        ///The name of the movie that will be added
        /// </summary>
        public string MovieTitle { get; set; }

        /// <summary>
        /// List of wishlist movies that are in databse.
        /// </summary>
        public List<string> Wishlist { get; set;}

        /// <summary>
        /// WishlistViewModel initialization
        /// </summary>
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
