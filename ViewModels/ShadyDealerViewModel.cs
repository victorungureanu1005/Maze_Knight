using Maze_Knight.Commands;
using Maze_Knight.Models;
using Maze_Knight.Models.Items;
using Maze_Knight.StaticClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Maze_Knight.ViewModels
{
    //This class get's instantiated within the Town view model
    public class ShadyDealerViewModel : BaseViewModel
    {

        #region Backing Fields
        private ShadyDealerModel _shadyDealer;
        private Player _player;
        //Store the selected items in as selected in the ShadyDealerView
        private Item _shadyDealerInventorySelectedItem;
        private Item _playerInventorySelectedItem;
        //Message to be displayed in the View on the buy or sell actions
        private string _messageToBeDisplayed;
        #endregion

        #region Commands
        [JsonIgnore]
        public ICommand BuyCommand { get; set; }
        [JsonIgnore]
        public ICommand SellCommand { get; set; }

        [JsonConstructor]
        public ShadyDealerViewModel(ShadyDealerModel shadyDealer, Player player)
        {
            ShadyDealer = shadyDealer;
            Player = player;
            BuyCommand = new BuyCommand(this);
            SellCommand = new SellCommand(this);
            ShadyDealerInventorySelectedItem = null;
            PlayerInventorySelectedItem = null;
            MessageToBeDisplayed = "";
        }
        #endregion

        #region Constructor
        
        public ShadyDealerViewModel(Player player)
        {
            ShadyDealer = new ShadyDealerModel(player);
            Player = player;
            BuyCommand = new BuyCommand(this);
            SellCommand = new SellCommand(this);
            //Message to be displayed set to empty, this will contain the buy or sell messages
            MessageToBeDisplayed = "";
        }
        #endregion

        #region Properties
        public ShadyDealerModel ShadyDealer { get => _shadyDealer; set => _shadyDealer = value; }
        public Player Player { get => _player; set => _player = value; }
        //Store the selected items in as selected in the ShadyDealerView
        [JsonIgnore]
        public Item ShadyDealerInventorySelectedItem { get => _shadyDealerInventorySelectedItem; set => _shadyDealerInventorySelectedItem = value; }
        [JsonIgnore]
        public Item PlayerInventorySelectedItem { get => _playerInventorySelectedItem; set => _playerInventorySelectedItem = value; }
        //Message to be displayed in the View on the buy or sell actions
        [JsonIgnore]
        public string MessageToBeDisplayed { get => _messageToBeDisplayed; set { _messageToBeDisplayed = value; OnPropertyChanged(nameof(MessageToBeDisplayed)); } }

        #endregion

    }
}
