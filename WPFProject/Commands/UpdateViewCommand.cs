using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WPFProject.ViewModels;

namespace WPFProject.Commands
{
    public class UpdateViewCommand : ICommand
    {

        private MainWindowVievModel viewModel;

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Constructor that takes view model to set private field
        /// </summary>
        /// <param name="viewModel"></param>
        public UpdateViewCommand(MainWindowVievModel viewModel)
        {
            this.viewModel = viewModel;
        }

        /// <summary>
        /// Method that always return true. Always change view
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        ///  Method that takes parameter and based on that decide which model view should be created
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {

            string param = parameter.ToString();


            switch (param)
            {
                case "List":
                    viewModel.SelectedViewModel = new ListViewModel();
                    break;
                case "EditMovie":
                    viewModel.SelectedViewModel = new EditMovieViewModel();
                    break;
                case "AddMovie":
                    viewModel.SelectedViewModel = new AddMovieViewModel();
                    break;
                case "DeleteMovie":
                    viewModel.SelectedViewModel = new DeleteMovieViewModel();
                    break;
                case "Settings":
                    viewModel.SelectedViewModel = new SettingsViewModel();
                    break;
                case "Wishlist":
                    viewModel.SelectedViewModel = new WishlistViewModel();
                    break;

            }

        }
    }
}
