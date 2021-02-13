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
                throw new ArgumentException();
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
                throw new ArgumentException();
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
                throw new ArgumentException();
            }
        }

    }
}
