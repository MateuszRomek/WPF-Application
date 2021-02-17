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
        /// <summary>
        /// The property is set when the user enters data into the TextBox on the Add New User row
        /// </summary>
        public string NewUserName { get; set; }
        /// <summary>
        /// The property is set when the user enters data into the TextBox on the Add New Genre row
        /// </summary>
        public string NewGenreName { get; set; }
        /// <summary>
        /// The property is set when the user enters data into the TextBox on the Add New Platform row
        /// </summary>
        public string NewPlatformName { get; set; }

        /// <summary>
        /// Property that manages IsEnabled property on Add User Button
        /// </summary>
        public bool IsUserNameEnabled { get; set; }
        /// <summary>
        /// Property that manages IsEnabled property on Add User Button
        /// </summary>
        public bool IsGenreNameEnabled { get; set; }
        /// <summary>
        /// Property that manages IsEnabled property on Add User Button
        /// </summary>
        public bool IsPlatformNameEnabled { get; set; }
        /// <summary>
        /// ErrorMessage to inform users what went wrong.
        /// </summary>
        public string ErrorMessage { get; set; }

   
        #region Commands
        /// <summary>
        /// Command that executes when user click Button in Platform row
        /// </summary>
        public ICommand AddPlatform {get;set;}
        /// <summary>
        /// Command that executes when user click Button in Genre row
        /// </summary>
        public ICommand AddGenre {get;set;}
        /// <summary>
        /// Command that executes when user click Button in User row
        /// </summary>
        public ICommand AddUser {get;set;}
        #endregion


        /// <summary>
        /// SettinsViedModal Initialization 
        /// </summary>
        public SettingsViewModel() 
        {
            this.AddPlatform = new RelayCommand(PlatformClick);
            this.AddGenre = new RelayCommand(GenreClick);
            this.AddUser = new RelayCommand(UserClick);
            this.ErrorMessage = "";
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
            NewUserName = "";
            NewGenreName = "";
            NewPlatformName = "";
            if (!(result == "OK"))
            {
                ErrorMessage = result;
             
            } else
            {
                ErrorMessage = "";
            }

        }

    }
}
