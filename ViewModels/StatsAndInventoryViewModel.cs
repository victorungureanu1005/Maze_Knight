using Maze_Knight.Commands.StatsAndInventoryViewModelCommands;
using Maze_Knight.Models;
using Maze_Knight.Models.Items;
using Maze_Knight.StaticClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Maze_Knight.ViewModels
{
    public class StatsAndInventoryViewModel : BaseViewModel
    {
        #region Backingfields
        private Player _currentPlayer;
        private Weapon _selectedWeapon;
        private Armour _selectedArmour;
        #endregion

        #region Properties
        public Player CurrentPlayer { get => _currentPlayer; set => _currentPlayer = value; }
        public Weapon SelectedWeapon { get => _selectedWeapon; set => _selectedWeapon = value; }
        public Armour SelectedArmour { get => _selectedArmour; set => _selectedArmour = value; }
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
            //Set Commands
            AddStatPointLevelCommand = new AddStatPointLevelCommand();
            EquipCommand = new EquipCommand();
            ResetStatPointsCommand = new ResetStatPointsCommand();
            UnequipCommand = new UnequipCommand();
            //Set Player
            CurrentPlayer = PlayerInstances.CurrentPlayerInstance;

            CurrentPlayer.EquippedArmour = new Armour();
            CurrentPlayer.EquippedWeapon = new Bow();
        }
        #endregion
    }
}
