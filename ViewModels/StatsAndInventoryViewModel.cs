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
        private Weapon _selectedWeaponFromInventory;
        private Armour _selectedArmourFromInventory;
        private Weapon _selectedEquippedWeapon;
        private Armour _selectedEquippedArmour;
        private int _addedMaxHealthStats = 0;
        private int _addedSwordSkillBonusStats = 0;
        private int _addedBowSkillBonusStats = 0;
        private int _addedHalberdSkillBonusStats = 0;
        #endregion

        #region Properties
        public Player CurrentPlayer { get => _currentPlayer; set => _currentPlayer = value; }
        public Weapon SelectedWeaponFromInventory { get => _selectedWeaponFromInventory; set => _selectedWeaponFromInventory = value; }
        public Armour SelectedArmourFromInventory { get => _selectedArmourFromInventory; set => _selectedArmourFromInventory = value; }
        public Weapon SelectedEquippedWeapon { get => _selectedEquippedWeapon; set => _selectedEquippedWeapon = value; }
        public Armour SelectedEquippedArmour { get => _selectedEquippedArmour; set => _selectedEquippedArmour = value; }
        public int AddedMaxHealthStats { get => _addedMaxHealthStats; set => _addedMaxHealthStats = value; }
        public int AddedSwordSkillBonusStats { get => _addedSwordSkillBonusStats; set => _addedSwordSkillBonusStats = value; }
        public int AddedBowSkillBonusStats { get => _addedBowSkillBonusStats; set => _addedBowSkillBonusStats = value; }
        public int AddedHalberdSkillBonusStats { get => _addedHalberdSkillBonusStats; set => _addedHalberdSkillBonusStats = value; }

        #endregion

        #region Commands
        public ICommand AddStatPointsCommand { get; set; }
        public ICommand ResetStatPointsCommand { get; set; }

        #endregion

        #region Constructor
        public StatsAndInventoryViewModel()
        {
            //Set Player
            CurrentPlayer = PlayerInstances.CurrentPlayerInstance;
            //Set Commands
            AddStatPointsCommand = new AddStatPointsCommand(this);
            ResetStatPointsCommand = new ResetStatPointsCommand(this);
        }
        #endregion
    }
}
