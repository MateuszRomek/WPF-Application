using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WPFProject.Base;
using WPFProject.Commands;
using WPFProject.DB.Data;
using WPFProject.DB.Models;
using WPFProject.Services;

namespace WPFProject.ViewModels
{
    public class SettingsViewModel : BaseViewModel, IDataErrorInfo
    {
        public string NewUserName { get; set; }

        public string NewGenreName { get; set; }

        public string NewPlatformName { get; set; }

        public bool IsUserNameEnabled { get; set; }
        public bool IsGenreNameEnabled { get; set; }
        public bool IsPlatformNameEnabled { get; set; }
        public string ErrorString { get; set; }

        /// <summary>
        /// Commands that are executed in Settings View.
        /// </summary>
        #region Commands

        public ICommand AddPlatform {get;set;}
        public  ICommand AddGenre {get;set;}
        public  ICommand AddUser {get;set;}
        #endregion


        /// <summary>
        /// Constructor setting up Commands
        /// </summary>
        public SettingsViewModel() 
        {
            this.AddPlatform = new RelayCommand(PlatformClick);
            this.AddGenre = new RelayCommand(GenreClick);
            this.AddUser = new RelayCommand(UserClick);
            this.ErrorString = "";
        }

        #region validation
        /// <summary>
        /// Returns empty string
        /// </summary>
        public string Error
        {
            get { return string.Empty; }
        }
        /// <summary>
        /// Implements IDataErrorInfo to notify user about incorrect input
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get
            {

                switch(columnName)
                {
                    case "NewUserName":
                        if (!String.IsNullOrEmpty(NewUserName)) {
                            IsUserNameEnabled = true;
                        } else
                        {
                            IsUserNameEnabled = false;
                        }
                        return "";
                    case "NewGenreName":
                        if (!String.IsNullOrEmpty(NewGenreName))
                        {
                            IsGenreNameEnabled = true ;
                        } else
                        {
                            IsGenreNameEnabled = false;
                        }
                        return "";
                    case "NewPlatformName":
                        if (!String.IsNullOrEmpty(NewPlatformName))
                        {
                            IsPlatformNameEnabled = true;
                        } else
                        {
                            IsPlatformNameEnabled = false;
                        }
                        return "";
                    default:
                        return "";
                        
                }

            }
        }
        #endregion
        private void UserClick()
        {
            User user = new User() { UserName = NewUserName };
            var result = AddDbRecordService.AddUser(user);
            ResultHandler(result);
        }
        private void GenreClick()
        {
            Genre genre = new Genre() { GenreName = NewGenreName };
            var result = AddDbRecordService.AddGenre(genre);
            ResultHandler(result);
        }
        private void PlatformClick()
        {
            Platform platform = new Platform() { PlatformName = NewPlatformName };
            var result = AddDbRecordService.AddPlatform(platform);
            ResultHandler(result);
        }

        private void ResultHandler(string result) 
        {
            if(!(result == "OK"))
            {
                ErrorString = result;   
            } else
            {
                ErrorString = "";
            }

        }

    }
}
