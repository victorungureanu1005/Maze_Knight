using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Maze_Knight;
using Maze_Knight.Commands;
using Maze_Knight.Views;
using System.Text.Json;
using Maze_Knight.StaticClasses;
using Maze_Knight.Models;
using System.IO;

namespace Maze_Knight.ViewModels
{
    public class AppWindowViewModel : BaseViewModel
    {
        //Sets the initial view model at the start of the app
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
            //Deserialize the Lastest Played Player Instnace
            if (File.Exists(@"c:\Lala\CurrentPlayerInstance.json") && File.Exists(@"c:\Lala\CurrentPlayerAvailableShadyDealerViewModel.json"))
            {
                PlayerInstances.CurrentPlayerInstance = JsonSerializer.Deserialize<Player>(File.ReadAllText(@"c:\Lala\CurrentPlayerInstance.json"));
                PlayerInstances.CurrentPlayerAvailableShadyDealerViewModel = JsonSerializer.Deserialize<ShadyDealerViewModel>(File.ReadAllText(@"c:\Lala\CurrentPlayerAvailableShadyDealerViewModel.json"));
            }
            
            //Initialize the Command
            UpdateViewCommand = new UpdateViewCommand(this);
        }

    }
}
