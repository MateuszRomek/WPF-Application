using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using WPFProject.DB.Data;

namespace WPFProject.Services
{
    public static class DeleteDbRecordService
    {

        public static string DeleteMovie (string movieTitle)
        {
            try
            {
                using (var context = new MovieCatalogContext())
                {

                    var movie = context.Movies
                        .SingleOrDefault(m => m.Title.ToLower().Trim() == movieTitle.ToLower().Trim());

                    if(movie == null)
                    {
                        return "Nie ma takiego filmu";
                    }

                    context.Movies.Remove(movie);
                    context.SaveChanges();
                    return "OK";

                }
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static string DeleteWishlistItem(string movieTitle)
        {
            try
            {
                using(var context = new MovieCatalogContext())
                {
                    var wishlistMovieExist = context.Wishlist.Any(w => w.MovieTitle.ToLower().Trim() == movieTitle.Trim().ToLower());
                    if (!wishlistMovieExist) return "Nie masz takiego filmu na liście \"Do obejrzenia \"";

                    var wishlistItem = context.Wishlist.SingleOrDefault(w => w.MovieTitle.ToLower().Trim() == movieTitle.ToLower().Trim());
                    context.Wishlist.Remove(wishlistItem);
                    context.SaveChanges();
                    return "OK";
                }


            } catch( Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
