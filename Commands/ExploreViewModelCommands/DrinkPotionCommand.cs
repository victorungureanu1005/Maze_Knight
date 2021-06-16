using Maze_Knight.Models;
using Maze_Knight.Models.Items;
using Maze_Knight.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Maze_Knight.Commands.ExploreViewModelCommands
{
    public class DrinkPotionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private Player _currentPlayer;
        ExploreViewModel _currentExploreViewModel;

        public DrinkPotionCommand(Player player, ExploreViewModel exploreViewModel)
        {
            _currentPlayer = player;
            _currentExploreViewModel = exploreViewModel;
        }
        public bool CanExecute(object parameter)
        {
            //This checks if there are any potions in the inventory of the player
            if (_currentPlayer.PlayerInventory.InventoryCollection.OfType<Potion>().Any())
            {
                return true;
            }
            else return false;
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                //Run the Drink Potion method in the player object
                Potion potion = _currentPlayer.PlayerInventory.InventoryCollection.OfType<Potion>().First();
                _currentExploreViewModel.ReportedMessages = $"Potion restored {potion.RestoredHealth} health!";
                _currentPlayer.DrinkPotion(potion);
                //Trigger requery. Check if condition is met to disable button in the view
                CommandManager.InvalidateRequerySuggested();
            }
        }
    }
}
