using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Maze_Knight;
using Maze_Knight.Commands;
using Maze_Knight.Views;

namespace Maze_Knight.ViewModels
{
    public class AppWindowViewModel : BaseViewModel
    {


        //sets the initial view model at the start of the app
        private static BaseViewModel initialAppViewModel = new MainMenuViewModel();


        #region SelectedViewModel
        //Fullprop SelectedViewModel Bound to the AppWindow xaml
        private BaseViewModel _selectedViewModel = initialAppViewModel;

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        #endregion

        public ICommand UpdateViewCommand { get; set; }

        public AppWindowViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
        }
      
    }
}
