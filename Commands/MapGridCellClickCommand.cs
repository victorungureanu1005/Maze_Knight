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

            //Check if clicked cell corresponds to the move options of the player and player is not locked
            if (moveOptions.Contains(clickedPosition) && !PlayerInstances.CurrentPlayerInstance.PlayerIsLocked)
            {
               if(PlayerInstances.CurrentPlayerInstance.SuppliesLeft <= 0)
                {
                    PlayerInstances.CurrentPlayerInstance.Die("You went out of supplies... you faced a terrible death");
                    return false;
                }
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
                //Remove 1 supply from the player
                PlayerInstances.CurrentPlayerInstance.SuppliesLeft--;

                if (_clickedMapGridCell.EnemyIsHere)
                {
                    //Lock player to not move. It will get unstuck if the Battle Command is ran
                    PlayerInstances.CurrentPlayerInstance.PlayerIsLocked = true;
                    //Update the TextBlock on the ExploreView indicating what EnemySubType has been engaged
                    ((ExploreViewModel)Mediator.TheApp.SelectedViewModel).EnemyEngagedMessage = _clickedMapGridCell.Enemy.EnemySubType.ToString()+"Attack!";
                    
                    
                    //BattleSystem battle = new BattleSystem(PlayerInstances.CurrentPlayerInstance, _clickedMapGridCell.Enemy, _clickedMapGridCell);
                    //battle.Battle();

                }

                if (_clickedMapGridCell.ExitIsHere)
                {
                    //Sets explore succes to true to trigger User control
                    PlayerInstances.CurrentPlayerInstance.ExploreSuccess = true;
                    //WARNING - this needs to be changed - setting property to false to have the ExploreView Disabled
                    PlayerInstances.CurrentPlayerInstance.IsAlive = false;
                    PlayerInstances.CurrentPlayerInstance.ExploreSuccessMethod();

                }
            }
        }


    }
}
