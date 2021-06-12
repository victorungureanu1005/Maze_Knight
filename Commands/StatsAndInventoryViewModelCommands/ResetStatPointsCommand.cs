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
    public class ResetStatPointsCommand : ICommand
    {
        private StatsAndInventoryViewModel _currentStatsAndInventoryViewModel;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public ResetStatPointsCommand(StatsAndInventoryViewModel statsAndInventoryViewModel)
        {
            _currentStatsAndInventoryViewModel = statsAndInventoryViewModel;
        }


        public bool CanExecute(object parameter)
        {
            //Checking if there were any stat points added, if yes, run the command. 
            if (_currentStatsAndInventoryViewModel.AddedMaxHealthStats + _currentStatsAndInventoryViewModel.AddedBowSkillBonusStats +
                _currentStatsAndInventoryViewModel.AddedSwordSkillBonusStats + _currentStatsAndInventoryViewModel.AddedHalberdSkillBonusStats
                 > 0)
            {
                return true;
            }
            else return false;
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                //Go through each and every AddedStatPointsValue and see whether anything was added, if yes, remove from stats (negative value)
                //and add to stat points and also reset the added statpoints buttons. 

                while (_currentStatsAndInventoryViewModel.AddedMaxHealthStats > 0)
                {
                    _currentStatsAndInventoryViewModel.CurrentPlayer.IncreaseMaxHealth(-(int)PlayerStatsPerPoint.MaxHealth);
                    _currentStatsAndInventoryViewModel.AddedMaxHealthStats--;
                    _currentStatsAndInventoryViewModel.CurrentPlayer.StatPoints++;
                }
                while (_currentStatsAndInventoryViewModel.AddedSwordSkillBonusStats > 0)
                {
                    _currentStatsAndInventoryViewModel.CurrentPlayer.IncreaseSwordSkillLevel(-(int)PlayerStatsPerPoint.SwordSkillLevel);
                    _currentStatsAndInventoryViewModel.AddedSwordSkillBonusStats--;
                    _currentStatsAndInventoryViewModel.CurrentPlayer.StatPoints++;
                }
                while (_currentStatsAndInventoryViewModel.AddedBowSkillBonusStats > 0)
                {
                    _currentStatsAndInventoryViewModel.CurrentPlayer.IncreaseBowSkillLevel(-(int)PlayerStatsPerPoint.BowSkillLevel);
                    _currentStatsAndInventoryViewModel.AddedBowSkillBonusStats--;
                    _currentStatsAndInventoryViewModel.CurrentPlayer.StatPoints++;
                }
                while (_currentStatsAndInventoryViewModel.AddedHalberdSkillBonusStats > 0)
                {
                    _currentStatsAndInventoryViewModel.CurrentPlayer.IncreaseHalberdSkillLevel(-(int)PlayerStatsPerPoint.HalberdSkillLevel);
                    _currentStatsAndInventoryViewModel.AddedHalberdSkillBonusStats--;
                    _currentStatsAndInventoryViewModel.CurrentPlayer.StatPoints++;
                }
                //Trigger requery. Check if condition is met to disable button in the view
                CommandManager.InvalidateRequerySuggested();
            }
        }
    }
}
