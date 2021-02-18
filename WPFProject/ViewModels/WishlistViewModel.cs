using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WPFProject.Base;
using WPFProject.Commands;
using WPFProject.DB.Data;
using WPFProject.Services;

namespace WPFProject.ViewModels
{
    public class WishlistViewModel : BaseViewModel,  IDataErrorInfo
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
        /// User that added movie to the wishlist. This value is set by default (in View) to Anonymous user
        /// </summary>
        public int User { get; set; }

        /// <summary>
        /// List of wishlist movies that are in databse.
        /// </summary>
        public List<WishlistUser> Wishlist { get; set;}

        /// <summary>
        /// This list represents the Users that are defined in the database. It is filled when the view loads.
        /// </summary>

        public List<DB.Models.User> AvaliableUsers { get; set; }

        /// <summary>
        /// This field determines if user can click Add button to create new movie.
        /// The button is enabled when the user completes the MovieTitle field. Otherwise, it is disabled.
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// WishlistViewModel initialization
        /// </summary>
        public WishlistViewModel()
        {
            this.AddAction = new RelayCommand(AddMovieToWishlist);
            this.DeleteAction = new RelayCommand(RemoveMovieFromWishlist);
            this.LoadData = new RelayCommand(LoadWishlistData);
        }

        /// <summary>
        /// Public method that returns empty string. Implemented from IDataErrorInfo interface
        /// </summary>
        public string Error
        {
            get { return string.Empty; }
        }
        /// <summary>
        /// Public method that returns and manages IsEnabled property. 
        /// Implemented from IDataErrorInfo interface.
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get
            {
                if ("MovieTitle" == columnName && String.IsNullOrEmpty(MovieTitle))
                {
                    IsEnabled = false;
                    return "Enter Movie Name";
                }
                else
                {
                    if (!String.IsNullOrEmpty(MovieTitle))
                    {
                        IsEnabled = true;
                    }
                    return "";
                }
            }
        }
        private void AddMovieToWishlist() 
        {
            var result = AddDbRecordService.AddMovieToWishlist(MovieTitle, User);
            HandleResult(result);
            LoadWishlistData();
        }

        private void RemoveMovieFromWishlist() 
        {
            var result = DeleteDbRecordService.DeleteWishlistItem(MovieTitle, User);
            HandleResult(result);
            LoadWishlistData();

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

        private void LoadWishlistData()
        {
            try
            {
                using(var  context = new MovieCatalogContext())
                {
                    var wishlist = context.Wishlist.Join( context.Users,
                        wishlist => wishlist.User.Id,
                        user => user.Id,
                        (wishlist, user) => new WishlistUser(wishlist.MovieTitle, user.UserName)
                        ).ToList();
                    Wishlist = wishlist;
                    var users = context.Users.ToList();
                    AvaliableUsers = users;
                }

            } catch (Exception e )
            {
                throw new Exception(e.Message);
            }
        }
    }
}
