using Maze_Knight.Models;
using Maze_Knight.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Maze_Knight.Commands
{
    public class UseRuneCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Player currentPlayer;
        public UseRuneCommand(Player player)
        {
            currentPlayer = player;
        }
        public bool CanExecute(object parameter)
        {
            if (currentPlayer.PlayerInventory.InventoryCollection.OfType<Rune>().Any())
            {
                return true;
            }
            else return false;
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                currentPlayer.PlayerInventory.InventoryCollection.Remove(currentPlayer.PlayerInventory.InventoryCollection.OfType<Rune>().First());
                currentPlayer.ActivateRune();
            }
        }
    }
}
