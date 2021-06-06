using Maze_Knight.Models.Comparers;
using Maze_Knight.Models.Enums;
using Maze_Knight.Models.Items;
using Maze_Knight.StaticClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models
{
    public class Player : BaseModel
    {
        #region Backing Fields
        //Generic Player information
        private string _name;
        private int _level;
        private int _goldDust;
        private int _currentExperience;
        private int _statPoints;
        private Inventory _playerInventory = new Inventory();
        private bool _newShadyDealerAvailable = true;

        //Player selected items
        private bool _isWeaponEquiped;
        private bool _isArmourEquiped;
        private bool _isAccesoryEquiped;

        //Player Stats
        private int _health = 5000000;
        private bool _isAlive = true;
        private int _minDamage = 25;
        private int _maxDamage = 40;
        private PlayerSelectedWeapon _playerSelectedWeapon = PlayerSelectedWeapon.Sword;
        private bool _runeActive = false;
        private int _runeNumberOfTurnsActive;
        private int _swordSkillLevel = 1;
        private int _bowSkillLevel = 2;
        private int _halberdSkillLevel = 3;
        private int _humanoidResistance = 1;
        private int _mysticalResistance = 1;

        //Player Location
        private int[] _playerLocation;
        private MapGridCell _cellOfPlayerLocation;
        private bool _playerIsLocked = false;

        #endregion

        #region Generic Player Information Properties

        //Name of Player
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        //Level of Player
        public int Level
        {
            get { return _level; }
            set { _level = value; OnPropertyChanged(nameof(Level)); }
        }

        //Gold Dust of Player
        public int GoldDust
        {
            get { return _goldDust; }
            set { _goldDust = value; OnPropertyChanged(nameof(GoldDust)); }
        }

        //Current Experience of Player
        public int CurrentExperience
        {
            get { return _currentExperience; }
            set { _currentExperience = value; OnPropertyChanged(nameof(CurrentExperience)); }
        }

        //Statpoints of Player
        public int StatPoints
        {
            get { return _statPoints; }
            set { _statPoints = value; OnPropertyChanged(nameof(StatPoints)); }
        }

        //Inventory of Player
        public Inventory PlayerInventory
        {
            get { return _playerInventory; }
            set { _playerInventory = value; OnPropertyChanged(nameof(PlayerInventory)); }
        }
        //specify whether new shadydealer can be created
        public bool NewShadyDealerAvailable { get => _newShadyDealerAvailable; set => _newShadyDealerAvailable = value; }


        #endregion

        #region Player Selected Items

        //Weapon is equiped or no
        public bool IsWeaponEquiped
        {
            get { return _isWeaponEquiped; }
            set { _isWeaponEquiped = value; }
        }

        //Armour is equiped or no
        public bool IsArmourEquiped
        {
            get { return _isArmourEquiped; }
            set { _isArmourEquiped = value; }
        }

        //Accesory is equiped or no
        public bool IsAccesoryEquiped
        {
            get { return _isAccesoryEquiped; }
            set { _isAccesoryEquiped = value; }
        }

        #endregion

        #region Player Stats Properties

        //Health of Player
        public int Health
        {
            get { return _health; }
            set { _health = value; OnPropertyChanged(nameof(Health)); }
        }

        //Is Alive boolean
        public bool IsAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; OnPropertyChanged(nameof(IsAlive)); }
        }

        //Min Damage dealth with all weapons
        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value; OnPropertyChanged(nameof(MinDamage)); }
        }

        //Max Damage dealth with all weapons
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; OnPropertyChanged(nameof(MaxDamage)); }
        }

        //Player Selected Weapon
        public PlayerSelectedWeapon PlayerSelectedWeapon
        {
            get { return _playerSelectedWeapon; }
            set { _playerSelectedWeapon = value; OnPropertyChanged(nameof(PlayerSelectedWeapon)); }
        }

        //Is player rune active or not
        public bool RuneActive
        {
            get { return _runeActive; }
            set { _runeActive = value; OnPropertyChanged(nameof(RuneActive)); }
        }

        //Number of turns left for rune activity
        public int RuneNumberOfTurnsActive
        {
            get { return _runeNumberOfTurnsActive; }
            set { _runeNumberOfTurnsActive = value; OnPropertyChanged(nameof(RuneNumberOfTurnsActive)); }
        }

        //Sword Skill
        public int SwordSkillLevel
        {
            get { return _swordSkillLevel; }
            set { _swordSkillLevel = value; OnPropertyChanged(nameof(SwordSkillLevel)); }
        }

        //Archer Skill
        public int BowSkillLevel
        {
            get { return _bowSkillLevel; }
            set { _bowSkillLevel = value; OnPropertyChanged(nameof(BowSkillLevel)); }
        }

        //Halberd Skill
        public int HalberdSkillLevel
        {
            get { return _halberdSkillLevel; }
            set { _halberdSkillLevel = value; OnPropertyChanged(nameof(HalberdSkillLevel)); }
        }

        //Resistance to eumanoid enemies
        public int HumanoidResistance
        {
            get { return _humanoidResistance; }
            set { _humanoidResistance = value; OnPropertyChanged(nameof(HumanoidResistance)); }
        }

        //Resistance to mystical enemies
        public int MysticalResistance
        {
            get { return _mysticalResistance; }
            set { _mysticalResistance = value; OnPropertyChanged(nameof(MysticalResistance)); }
        }


        #endregion

        #region Player Location Propreties

        //Player Location on Map
        public int[] PlayerLocation
        {
            get { return _playerLocation; }
            set { _playerLocation = value; OnPropertyChanged(nameof(PlayerLocation)); }
        }

        public MapGridCell CellOfPlayerLocation
        {
            get { return _cellOfPlayerLocation; }
            set { _cellOfPlayerLocation = value; OnPropertyChanged(nameof(CellOfPlayerLocation)); }
        }
        //Is player locked or can he move on the map grid? Needed for the MapGridCellClickCommand and BattleCommand interaction
        public bool PlayerIsLocked
        {
            get { return _playerIsLocked; }
            set { _playerIsLocked = value; OnPropertyChanged(nameof(PlayerIsLocked)); }
        }

        

        #endregion

        #region Methods on Player Location

        public HashSet<List<int>> GetMoveOptions()
        {
            var _comparer = new CoordinatesEqualityComparer();
            //Getting current location and storing the column and row number
            int[] _currentPlayerLocation = this.PlayerLocation;
            int column = _currentPlayerLocation[0];
            int row = _currentPlayerLocation[1];
            //Creating a new HashSet which will be updated and returned
            HashSet<List<int>> _moveOptions = new HashSet<List<int>>(_comparer);

            //Start creating the options, player can only move in cross directions 1 step at a time, not outside of bounds
            //Checking first the left and upper bounds (column and row should not be less than 0) and adding the options to the HashSet
            if (column - 1 < 0)
            {
                if (row - 1 < 0)
                {
                    _moveOptions.Add(new List<int> { column + 1, row });
                    _moveOptions.Add(new List<int> { column, row + 1 });
                }
                else
                {
                    _moveOptions.Add(new List<int> { column + 1, row });
                    _moveOptions.Add(new List<int> { column, row + 1 });
                    _moveOptions.Add(new List<int> { column, row - 1 });
                }
            }
            else
            {
                if (row-1 < 0)
                {
                    _moveOptions.Add(new List<int> { column + 1, row });
                    _moveOptions.Add(new List<int> { column, row + 1 });
                    _moveOptions.Add(new List<int> { column - 1, row });
                }
                else
                {
                    _moveOptions.Add(new List<int> { column + 1, row });
                    _moveOptions.Add(new List<int> { column, row + 1 });
                    _moveOptions.Add(new List<int> { column, row - 1 });
                    _moveOptions.Add(new List<int> { column - 1, row });
                }
            }

            //Instantiating MapMeasures class relative to level in order to use the methods
            MapMeasures _mapMeasures = new MapMeasures(this);

            //HashSet containing to be removed items;
            HashSet<List<int>> _toRemoveOptions = new HashSet<List<int>>();

            //Checking then from the existing options whether options go out of bounds, checking right and bottom bounds ([0] - column; [1] - row)
            foreach (var item in _moveOptions)
            {

                if (item[0] > _mapMeasures.GetMaxColumn()-1 || item[1] > _mapMeasures.GetMaxRow()-1)
                {
                    _toRemoveOptions.Add(item);
                }
            }

            foreach (var item in _toRemoveOptions)
            {
                _moveOptions.Remove(item);
            }

            return _moveOptions;
        }

        #endregion

        #region Player Stats Methods
        //Receive experience method, experience should always be positive or exception is thrown
        public void ReceiveExperience(int experience)
        {
            if (experience>=0)
            {
                if (experience + CurrentExperience >= ExperienceForNextLevel())
                {
                    CurrentExperience = (CurrentExperience + experience)-ExperienceForNextLevel();
                    LevelUp();
                }
                else CurrentExperience += experience;
            }
            else throw new Exception("Experience received cannot be negative");
        }

        //Receive gold dust method, gold dust should always be positive or exception is thrown
        public void ReceiveGoldDust(int goldDust)
        {
            if (goldDust>=0)
            {
                GoldDust += goldDust;
            }
            else throw new Exception("Gold dust received cannot be negative");
        }

        //Increase health
        public void IncreaseHealth(int healthAmount)
        {
            if (healthAmount <= 0)
                return;
            if (healthAmount + Health <= 100)
                Health += healthAmount;
            else Health = 100;
        }

        //Decrease health
        public void DecreaseHealth(int healthAmount)
        {
            if (healthAmount <= 0)
                return;
            if (Health - healthAmount <= 0)
            {
                Health = 0;
                //Some implementation to be done here
                Die();
            }
            else Health -= healthAmount;
        }

        #endregion

        #region Player Weapon and Rune Methods

        //Change weapon currently had by player
        public void ChangeWeapon(PlayerSelectedWeapon selectedWeapon)
        {
            PlayerSelectedWeapon = selectedWeapon;
        }

        //Activate rune of the player
        public void ActivateRune()
        {
            RuneActive = true;
            RuneNumberOfTurnsActive = 3;
        }

        #endregion

        #region Helper Functions

        //Level up method
        private void LevelUp()
        {
            Level++;
            StatPoints += 3;
        }

        //Provides int for experience needed for next level;
        private int ExperienceForNextLevel()
        {
            const float INCREASE_FACTOR = 25f;
            const int INCREASE_MARGIN = 5;
            return (int)Math.Round((Level*INCREASE_FACTOR) + INCREASE_MARGIN);
        }

        #endregion

        #region Game Changing Methods

        //Player dies, receives a message and has to go back to the Main Menu
        public void Die()
        {
            IsAlive = false;
            throw new Exception("YOU DIED!");
        }

        #endregion

    }
}

