using Maze_Knight.Models;
using Maze_Knight.Models.Enums.PlayerStatsPerPoint;
using Maze_Knight.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Maze_Knight.Commands.StatsAndInventoryViewModelCommands
{
    public class AddStatPointsCommand : ICommand
    {
        //Set EventHandler to update accordingly when Requery is triggered
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        //Private fields - references created
        private Player _currentPlayer;
        private StatsAndInventoryViewModel _currentStatsAndInventoryViewModel;

        //Constructor
        public AddStatPointsCommand(StatsAndInventoryViewModel statsAndInventoryViewModel)
        {
            _currentStatsAndInventoryViewModel = statsAndInventoryViewModel;
            _currentPlayer = _currentStatsAndInventoryViewModel.CurrentPlayer;
        }

        public bool CanExecute(object parameter)
        {
            //Check if there are available stat points
            if (_currentPlayer.StatPoints > 0)
            {
                return true;
            }
            else return false;
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                switch (parameter.ToString())
                {
                    //On Health, also add the health added to current health
                    case "MaxHealth":
                        _currentPlayer.IncreaseMaxHealth((int)PlayerStatsPerPoint.MaxHealth);
                        _currentPlayer.StatPoints--;
                        _currentStatsAndInventoryViewModel.AddedMaxHealthStats++;
                        break;
                    case "SwordSkillLevel":
                        _currentPlayer.IncreaseSwordSkillLevel((int)PlayerStatsPerPoint.SwordSkillLevel);
                        _currentPlayer.StatPoints--;
                        _currentStatsAndInventoryViewModel.AddedSwordSkillBonusStats++;
                        break;
                    case "BowSkillLevel":
                        _currentPlayer.IncreaseBowSkillLevel((int)PlayerStatsPerPoint.BowSkillLevel);
                        _currentPlayer.StatPoints--;
                        _currentStatsAndInventoryViewModel.AddedBowSkillBonusStats++;
                        break;
                    case "HalberdSkillLevel":
                        _currentPlayer.IncreaseHalberdSkillLevel((int)PlayerStatsPerPoint.HalberdSkillLevel);
                        _currentPlayer.StatPoints--;
                        _currentStatsAndInventoryViewModel.AddedHalberdSkillBonusStats++;
                        break;
                }
                //Trigger requery. Check if condition is met to disable button in the view
                CommandManager.InvalidateRequerySuggested();
            }
        }
    }
}
