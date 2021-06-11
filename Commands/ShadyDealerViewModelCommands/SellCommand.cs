using Maze_Knight.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Maze_Knight.Commands
{
    class SellCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private ShadyDealerViewModel _shadyDealerViewModel;

        public ShadyDealerViewModel ShadyDealerViewModel { get => _shadyDealerViewModel; set => _shadyDealerViewModel = value; }

        public SellCommand(ShadyDealerViewModel shadyDealerViewModel)
        {
            ShadyDealerViewModel = shadyDealerViewModel;
        }

        public bool CanExecute(object parameter)
        {
            if (ShadyDealerViewModel.PlayerInventorySelectedItem == null)
            {
                return false;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                //Add gold dust to the player
                ShadyDealerViewModel.Player.GoldDust += ShadyDealerViewModel.PlayerInventorySelectedItem.ItemSellPrice;
                //Remove item from the PlayerInventoryCollection and do not add it to the ShadyDealerInventoryCollection - if this is implemented, max number of grid components (max 8) for the ShadyDealerGrid in the View must be kept
                ShadyDealerViewModel.Player.PlayerInventory.InventoryCollection.Remove(ShadyDealerViewModel.PlayerInventorySelectedItem);
                //Set message according to the action performed
                ShadyDealerViewModel.MessageToBeDisplayed = $"You sold {ShadyDealerViewModel.PlayerInventorySelectedItem.ItemName} for {ShadyDealerViewModel.PlayerInventorySelectedItem.ItemSellPrice} gold dust!";
                //Reset the SelectedItem to null
                ShadyDealerViewModel.PlayerInventorySelectedItem = null;
            }
        }
    }
}
