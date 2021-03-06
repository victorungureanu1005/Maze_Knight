using Maze_Knight.Models;
using Maze_Knight.Models.Items;
using Maze_Knight.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Maze_Knight.Commands
{
    public class UseRuneCommand : ICommand
    {
        //Set EventHandler to update accordingly when Requery is triggered
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        private Player _currentPlayer;
        private ExploreViewModel _currentExploreViewModel;
        public UseRuneCommand(Player player, ExploreViewModel exploreViewModel)
        {
            _currentPlayer = player;
            _currentExploreViewModel = exploreViewModel;
        }
        public bool CanExecute(object parameter)
        {
            //This checks if there are any runes in the inventory of the player
            if (_currentPlayer.PlayerInventory.InventoryCollection.OfType<Rune>().Any())
            {
                return true;
            }
            else return false;
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                //Run activate rune method in the player object
                _currentPlayer.ActivateRune(_currentPlayer.PlayerInventory.InventoryCollection.OfType<Rune>().First());
                _currentExploreViewModel.ReportedMessages = "Rune was activated!";
                //Trigger requery. Check if condition is met to disable button in the view
                CommandManager.InvalidateRequerySuggested();
            }
        }
    }
}
