using Maze_Knight.Models;
using Maze_Knight.Models.Items;
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
        public UseRuneCommand(Player player)
        {
            _currentPlayer = player;
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
                //Removes runes from the inventory and activates is
                _currentPlayer.PlayerInventory.InventoryCollection.Remove(_currentPlayer.PlayerInventory.InventoryCollection.OfType<Rune>().First());
                _currentPlayer.ActivateRune();
                //Trigger requery. Check if condition is met to disable button in the view
                CommandManager.InvalidateRequerySuggested();
            }
        }
    }
}
