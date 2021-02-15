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
    }
}
