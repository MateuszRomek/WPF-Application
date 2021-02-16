using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPFProject.DB.Data;
using WPFProject.DB.Models;

namespace WPFProject.Services
{
    public static class AddDbRecordService
    {

        /// <summary>
        /// Checks a record in the User table. 
        /// If it exists, it returns a string. If not, it creates a record in the database and returns OK information of the string type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="record"></param>
        public static string AddUser (User record) 
        { 
            try
            {

                using(var context = new MovieCatalogContext())
                {
                    var exist = context.Users.Any(u => u.UserName.ToLower() == record.UserName.ToLower());
                    if(!exist)
                    {
                        context.Users.Add(record);
                        context.SaveChanges();
                        return "OK";
                    } else
                    {
                        return "Użytkownik o takiej nazwie już istnieje";
                    }
                }
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// Checks a record in the Genres table. 
        /// If it exists, it returns a string. If not, it creates a record in the database and returns OK information of the string type.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public static string AddGenre(Genre record)
        {
            try
            {

                using (var context = new MovieCatalogContext())
                {
                    var exist = context.Genres.Any(u => u.GenreName.ToLower() == record.GenreName.ToLower());
                    if (!exist)
                    {
                        context.Genres.Add(record);
                        context.SaveChanges();
                        return "OK";
                    }
                    else
                    {
                        return "Taki gatunek filmu już istnieje";
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// Checks a record in the Platrofm table. 
        /// If it exists, it returns a string. If not, it creates a record in the database and returns OK information of the string type.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public static string AddPlatform(Platform record)
        {
            try
            {

                using (var context = new MovieCatalogContext())
                {
                    var exist = context.Platforms.Any(u => u.PlatformName.ToLower() == record.PlatformName.ToLower());
                    if (!exist)
                    {
                        context.Platforms.Add(record);
                        context.SaveChanges();
                        return "OK";
                    }
                    else
                    {
                        return "Istnieje już platforma o takiej nazwie";
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Checks a record in the Movies table. 
        /// If it exists, it returns a string. If not, it creates a record in the database and returns OK information of the string type.
        /// </summary>
        /// <returns></returns>
        public static string AddMovie(string title, string description, int genreId, int platformId, int userId, int ratingId )
        {
            try
            {
                using(var context = new MovieCatalogContext())
                {

                    var movieExist = context.Movies.Any(m => m.Title.ToLower().Trim() == title.ToLower().Trim());

                    if (!movieExist)
                    {
                        var genre = context.Genres
                                    .Where(g => g.Id == genreId)
                                    .FirstOrDefault();

                        var user = context.Users
                            .Where(u => u.Id == userId)
                            .FirstOrDefault();


                        var platform = context.Platforms
                            .Where(g => g.Id == platformId)
                            .FirstOrDefault();

                        var rating = context.Ratings
                             .Where(r => r.Id == ratingId)
                             .FirstOrDefault();


                        Movie newMovie = new Movie()
                        {
                            Description = description,
                            Title = title,
                            Genre = genre,
                            Platform = platform,
                            Rating = rating,
                            User = user
                           
                        };

                        context.Movies.Add(newMovie);

                        context.SaveChanges();
                        return "OK";
                    } else
                    {
                        return "Film o takiej nazwie już istnieje";
                    }

                }



            } catch(Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        /// <summary>
        /// Checks a record in the Wishlist table. 
        /// If it exists, it returns a string. If not, it creates a record in the database and returns OK information of the string type.
        /// </summary>
        /// <returns></returns>
        public static string AddMovieToWishlist (string movieTitle)
        {
            try
            {
                using (var context = new MovieCatalogContext())
                {
                    var movieExist = context.Wishlist.Any(w => w.MovieTitle.ToLower().Trim() == movieTitle.ToLower().Trim());
                    if (movieExist) return "Film o takim tytule znajduje się już na Twojej liście do obejrzenia";

                    var wishlist = new Wishlist()
                    {
                        MovieTitle = movieTitle
                    };

                    context.Wishlist.Add(wishlist);
                    context.SaveChanges();
                    return "OK";
                }
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
