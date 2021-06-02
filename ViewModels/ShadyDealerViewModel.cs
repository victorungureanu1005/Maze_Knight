using Maze_Knight.Models;
using Maze_Knight.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.ViewModels
{
    //This class get's instantiated within the Town view model
    public class ShadyDealerViewModel : BaseViewModel
    {

        #region Backing Fields
        private ShadyDealerModel _shadyDealer;
        private Item shadyDealerInventorySelectedItem;
        private Item playerInventorySelectedItem;
        #endregion

        #region Constructor
        public ShadyDealerViewModel(Player player)
        {
            ShadyDealer = new ShadyDealerModel(player);
        }
        #endregion

        #region Properties
        public ShadyDealerModel ShadyDealer { get => _shadyDealer; set => _shadyDealer = value; }
        public Item ShadyDealerInventorySelectedItem { get => shadyDealerInventorySelectedItem; set => shadyDealerInventorySelectedItem = value; }
        public Item PlayerInventorySelectedItem { get => playerInventorySelectedItem; set => playerInventorySelectedItem = value; }
        #endregion

    }
}
