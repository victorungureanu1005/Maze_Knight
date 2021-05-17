using Maze_Knight.Models;
using Maze_Knight.StaticClasses;
using Maze_Knight.ViewModels;
using Maze_Knight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Maze_Knight.Commands
{
    class MapGridCellClickCommand : ICommand
    {
        //Constructor
        public MapGridCellClickCommand(MapGridCell mapGridCell)
        {
            _clickedMapGridCell = mapGridCell;
        }

        public MapGridCell _clickedMapGridCell;
        public MapGridCell _previousMapGridCell;


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //Find out the move options of the player
            var moveOptions = PlayerInstances.CurrentPlayerInstance.GetMoveOptions();
            List<int> clickedPosition = new List<int>();
            clickedPosition.Add(Grid.GetColumn((TextBlock)parameter));
            clickedPosition.Add(Grid.GetRow((TextBlock)parameter));

            //Check if clicked cell corresponds to the move options of the player
            if (moveOptions.Contains(clickedPosition))
            {
                return true;
            }
            else return false;
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                //Need to keep track of the current/previous player location and reset the values (hero not there anymore -> cell/location was explored)
                _previousMapGridCell = PlayerInstances.CurrentPlayerInstance.CellOfPlayerLocation;
                _previousMapGridCell.PlayerIsHere = false;
                _previousMapGridCell.WasExplored = true;
                //Changing player location based on click event - the player static instance keeps track of such information
                _clickedMapGridCell.PlayerIsHere = true;
                PlayerInstances.CurrentPlayerInstance.CellOfPlayerLocation = _clickedMapGridCell;
                PlayerInstances.CurrentPlayerInstance.PlayerLocation = new int[] { _clickedMapGridCell.CellColumnNumber, _clickedMapGridCell.CellRowNumber };

                if (_clickedMapGridCell.EnemyIsHere)
                {
                    ((ExploreViewModel)Mediator.theApp.SelectedViewModel).EnemyEngagedMessage = _clickedMapGridCell.Enemy.EnemySubType.ToString();
                    BattleSystem battle = new BattleSystem(PlayerInstances.CurrentPlayerInstance, _clickedMapGridCell.Enemy, _clickedMapGridCell);
                    battle.Battle();

                }
            }
        }


    }
}
