using Maze_Knight.Commands.StatsAndInventoryViewModelCommands;
using Maze_Knight.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Maze_Knight.ViewModels
{
    class StatsAndInventoryViewModel : BaseViewModel
    {
        #region Backingfields
        private Item _selectedInventoryItem;
        private Item _selectedEquippedItem;
        private 
        #endregion
        #region Properties
        #endregion
        #region Commands
        public ICommand AddStatPointLevelCommand { get; set; }
        public ICommand EquipCommand { get; set; }
        public ICommand ResetStatPointsCommand { get; set; }
        public ICommand UnequipCommand { get; set; }
        #endregion
        #region Constructor
        public StatsAndInventoryViewModel()
        {
            AddStatPointLevelCommand = new AddStatPointLevelCommand();
            EquipCommand = new EquipCommand();
            ResetStatPointsCommand = new ResetStatPointsCommand();
            UnequipCommand = new UnequipCommand();
        }
        #endregion
    }
}
