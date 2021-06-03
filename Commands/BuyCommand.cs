using Maze_Knight.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Maze_Knight.Commands
{
    class BuyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private ShadyDealerViewModel _shadyDealerViewModel;

        public ShadyDealerViewModel ShadyDealerViewModel { get => _shadyDealerViewModel; set => _shadyDealerViewModel = value; }

        public BuyCommand(ShadyDealerViewModel shadyDealerViewModel)
        {
            ShadyDealerViewModel = shadyDealerViewModel;
        }
        public bool CanExecute(object parameter)
        {
            //Check if player has enough gold dust
            if (ShadyDealerViewModel.ShadyDealerInventorySelectedItem.ItemBuyPrice <= ShadyDealerViewModel.Player.GoldDust)
            {
                //Check if player has enough inventory capacity - this is relevant as the grid of the ShadyDealerViewModel for the player is set to 4/4 = max of 16
                if (ShadyDealerViewModel.Player.PlayerInventory.InventoryCollection.Count() <= 15)
                {
                    return true;
                }
                ShadyDealerViewModel.MessageToBeDisplayed = "Not enough carry capacity!";
                return false;
            }
            else
            {
                ShadyDealerViewModel.MessageToBeDisplayed = "Not enough gold dust!";
                return false;
            }
        }

        public void Execute(object parameter)
        {
            //Check can execute condition
            if (CanExecute(parameter))
            {
                //Remove gold dust from the player
                ShadyDealerViewModel.Player.GoldDust -= ShadyDealerViewModel.ShadyDealerInventorySelectedItem.ItemBuyPrice;
                //Add item to the PlayerInventoryCollection and remove it from the ShadyDealerInventoryCollection
                ShadyDealerViewModel.Player.PlayerInventory.InventoryCollection.Add(ShadyDealerViewModel.ShadyDealerInventorySelectedItem);
                ShadyDealerViewModel.ShadyDealer.ShadyDealerInventory.InventoryCollection.Remove(ShadyDealerViewModel.ShadyDealerInventorySelectedItem);
                //Set message according to the action performed
                ShadyDealerViewModel.MessageToBeDisplayed = $"You bought {ShadyDealerViewModel.ShadyDealerInventorySelectedItem.ItemName} for {ShadyDealerViewModel.ShadyDealerInventorySelectedItem.ItemBuyPrice} gold dust!";
                //Reset the SelectedItem to null
                ShadyDealerViewModel.ShadyDealerInventorySelectedItem = null;
            }
        }
    }
}
