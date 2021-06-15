using Maze_Knight.Commands.SaveLoadSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Maze_Knight.StaticClasses;
using Maze_Knight.Models;

namespace Maze_Knight.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        #region Commands
        public ICommand ContinueGameCommand;
        public ICommand NewGameCommand;

        public MainMenuViewModel()
        {
            //Initialize Commands
            ContinueGameCommand = new ContinueGameCommand();
            NewGameCommand = new NewGameCommand();

        }

        #endregion
    }
}
