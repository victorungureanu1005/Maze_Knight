using Maze_Knight.Models.Comparers;
using Maze_Knight.Models.Enums;
using Maze_Knight.Models.Items;
using Maze_Knight.StaticClasses;
using Maze_Knight.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models
{
    public class Player : BaseModel
    {
        #region Constants
        //To be used in order to check whether inventory is full or not
        private const int MAX_INVENTORY_COLLECTION_COUNT = 16;
        //Used in the level up calculations
        const float EXPERIENCE_NEEDED_INCREASE_BASE = 25f;
        const int EXPERIENCE_NEEDED_INCREASE_MARGIN = 15;
        //Stat points received per level + MinMaxDamage bonus received
        const int STAT_POINTS_PER_LEVEL = 3;
        const int MIN_DAMAGE_RECEIVED_PER_LEVEL = 3;
        const int MAX_DAMAGE_RECEIVED_PER_LEVEL = 5;
        //Number of turns available of rune bonus after rune activation
        const int RUNE_NUMBER_OF_TURNS_AFTER_ACTIVATION = 3;
        //Supplies stats - number of moves
        const int BASE_SUPPLIES = 20;
        const int ADDITIONAL_SUPPLIES_PER_LEVEL = 1;
        //After death try again constants
        const int GOLD_DUST_LOST_ON_DEATH_PER_LEVEL = 5;
        const int GOLD_DUST_LOST_ON_FLIGHT = 10;
        //After Explore Success obtain gold dust
        const int GOLD_DUST_ON_EXPLORE_SUCCESS = 25;
        #endregion

        #region Backing Fields and Privates
        //Generic Player information
        private string _name;
        private int _level = 1;
        private int _goldDust = 200;
        private int _currentExperience = 0;
        private int _experienceNeededForLevelUp = 10;
        private int _statPoints;
        private Inventory _playerInventory = new Inventory();
        private Weapon _equippedWeapon = null;
        private Armour _equippedArmour = null;
        private bool _newShadyDealerAvailable = true;

        //Player Stats these are set to the initial settings
        private int _health;
        private int _maxHealth = 100;
        private bool _isAlive = true;
        private string _deathMessage;
        private bool _exploreSuccess = false;
        private int _suppliesLeft;
        private int _minDamage = 25;
        private int _maxDamage = 40;
        private PlayerSelectedWeapon _playerSelectedWeapon = PlayerSelectedWeapon.Sword;
        private bool _runeActive = false;
        private int _runeNumberOfTurnsActive;
        private int _swordSkillLevel = 1;
        private int _bowSkillLevel = 1;
        private int _halberdSkillLevel = 1;
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
        //Experience needed for Level up
        public int ExperienceNeededForLevelUp
        {
            get { return _experienceNeededForLevelUp; }
            set { _experienceNeededForLevelUp = value; OnPropertyChanged(nameof(ExperienceNeededForLevelUp)); }
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

        public Weapon EquippedWeapon
        {
            get { return _equippedWeapon; }
            set { _equippedWeapon = value; OnPropertyChanged(nameof(EquippedWeapon)); }
        }

        public Armour EquippedArmour
        {
            get { return _equippedArmour; }
            set { _equippedArmour = value; OnPropertyChanged(nameof(EquippedArmour)); }
        }


        //specify whether new shadydealer can be created
        public bool NewShadyDealerAvailable { get => _newShadyDealerAvailable; set => _newShadyDealerAvailable = value; }


        #endregion

        #region Player Stats Properties

        //Health of Player
        public int Health
        {
            get { return _health; }
            set { _health = value; OnPropertyChanged(nameof(Health)); }
        }

        //Max Health of Player
        public int MaxHealth
        {
            get { return _maxHealth; }
            set { _maxHealth = value; OnPropertyChanged(nameof(MaxHealth)); }
        }

        //Is Alive boolean
        public bool IsAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; OnPropertyChanged(nameof(IsAlive)); }
        }

        //Death Message generated by calling the die method - usable in the explore view and view model
        public string DeathMessage { get => _deathMessage; set { _deathMessage = value; OnPropertyChanged(nameof(DeathMessage)); } }

        //Checks whether Explore was successful or not - exit was reached
        public bool ExploreSuccess { get => _exploreSuccess; set { _exploreSuccess = value; OnPropertyChanged(nameof(ExploreSuccess)); } }

        //Supplies left = moves left on explore view model
        public int SuppliesLeft { get => _suppliesLeft; set { _suppliesLeft = value; OnPropertyChanged(nameof(SuppliesLeft)); } }

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

        [JsonIgnore]
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

        #region Constructor
        public Player()
        {
            //Set health to maxHealth
            Health = MaxHealth;
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
                if (row - 1 < 0)
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

                if (item[0] > _mapMeasures.GetMaxColumn() - 1 || item[1] > _mapMeasures.GetMaxRow() - 1)
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

        #region Player Receive Exp, Health, GoldDust, Supplies Methods
        //Receive experience method, experience should always be positive or exception is thrown
        public void ReceiveExperience(int experience)
        {
            if (experience >= 0)
            {
                if (experience + CurrentExperience >= ExperienceNeededForLevelUp)
                {
                    CurrentExperience = CurrentExperience + experience - ExperienceNeededForLevelUp;
                    LevelUp();
                }
                else CurrentExperience += experience;
            }
            else throw new Exception("Experience received cannot be negative");
        }

        //Receive gold dust method, gold dust should always be positive or exception is thrown
        public void ReceiveGoldDust(int goldDust)
        {
            if (goldDust >= 0)
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
            if (healthAmount + Health <= MaxHealth)
                Health += healthAmount;
            else Health = MaxHealth;
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
                Die("You took a fatal hit, well that was a good run...");
            }
            else Health -= healthAmount;
        }

        public void CalculateInitialSupplies(int level)
        {
            SuppliesLeft = BASE_SUPPLIES + (level * ADDITIONAL_SUPPLIES_PER_LEVEL);
        }
        #endregion

        #region Player Increase Stats Methods
        public void IncreaseMaxHealth(int value)
        {
            //Increase the Stat value
            MaxHealth += value;
            //Also increase current health value
            Health += value;
        }

        public void IncreaseSwordSkillLevel(int value)
        {
            SwordSkillLevel += value;
        }

        public void IncreaseBowSkillLevel(int value)
        {
            BowSkillLevel += value;
        }

        public void IncreaseHalberdSkillLevel(int value)
        {
            HalberdSkillLevel += value;
        }

        #endregion

        #region Player Weapon and Rune Methods

        //Change weapon currently had by player
        public void ChangeWeapon(PlayerSelectedWeapon selectedWeapon)
        {
            PlayerSelectedWeapon = selectedWeapon;
        }

        //Activate rune of the player
        public void ActivateRune(Rune rune)
        {
            RuneActive = true;
            RuneNumberOfTurnsActive = RUNE_NUMBER_OF_TURNS_AFTER_ACTIVATION;
            PlayerInventory.InventoryCollection.Remove(rune);
        }
        //Drinks potion
        public void DrinkPotion(Potion potion)
        {
            IncreaseHealth(potion.RestoredHealth);
            PlayerInventory.InventoryCollection.Remove(potion);
        }

        //Equip Weapon method used in the StatsAndInventory View
        public void EquipWeapon(Item item)
        {
            Weapon oldEquippedWeapon = EquippedWeapon;
            if (item is Weapon)
            {
                //Store already equipped Weapon in Collection before equiping the new one
                if (EquippedWeapon != null)
                {
                    PlayerInventory.InventoryCollection.Add(EquippedWeapon);
                }
                EquippedWeapon = (Weapon)item;
                //Adds the stats of the newEquippedWeapon
                ChangePlayerStatsEquipUnequipWeapon(+1, (Weapon)item);
                //Removes the stats of the oldEquippedWeapon
                if (oldEquippedWeapon != null)
                {
                    ChangePlayerStatsEquipUnequipWeapon(-1, oldEquippedWeapon);
                }
                PlayerInventory.InventoryCollection.Remove(item);
            }
        }
        //Equip Armour method used in the StatsAndInventory View
        public void EquipArmour(Item item)
        {
            Armour oldEquippedArmour = EquippedArmour;
            if (item is Armour)
            {
                //Store already equipped Armour in Collection before equiping the new one
                if (EquippedArmour != null)
                {
                    PlayerInventory.InventoryCollection.Add(EquippedArmour);
                }
                EquippedArmour = (Armour)item;
                //Adds the stats of the newEquippedArmour
                ChangePlayerStatsEquipUnequipArmour(+1, (Armour)item);
                //Removes the stats of the oldEquippedArmour
                if (oldEquippedArmour != null)
                {
                    ChangePlayerStatsEquipUnequipArmour(-1, oldEquippedArmour);
                }
                PlayerInventory.InventoryCollection.Remove(item);
            }
        }

        public void UnequipWeapon(Item item)
        {
            //Cannot exceed count of player inventory collection as not more than 16 can be displayed
            if (PlayerInventory.InventoryCollection.Count < MAX_INVENTORY_COLLECTION_COUNT)
            {
                ChangePlayerStatsEquipUnequipWeapon(-1, (Weapon)item);
                PlayerInventory.InventoryCollection.Add(EquippedWeapon);
                EquippedWeapon = null;
            }
            //Do nothing if inventory is full
        }
        public void UnequipArmour(Item item)
        {
            //Cannot exceed count of player inventory collection as not more than 16 can be displayed
            if (PlayerInventory.InventoryCollection.Count < MAX_INVENTORY_COLLECTION_COUNT)
            {
                ChangePlayerStatsEquipUnequipArmour(-1, (Armour)item);
                PlayerInventory.InventoryCollection.Add(EquippedArmour);
                EquippedArmour = null;
                //Do nothing if inventory is full
            }
        }
        //To be used in equip, unequip weapon methods
        public void ChangePlayerStatsEquipUnequipWeapon(int negativeOrPositiveOne, Weapon weapon)
        {
            SwordSkillLevel += negativeOrPositiveOne * weapon.SwordSkillBonus;
            BowSkillLevel += negativeOrPositiveOne * weapon.BowSkillBonus;
            HalberdSkillLevel += negativeOrPositiveOne * weapon.HalberdSkillBonus;
            MinDamage += negativeOrPositiveOne * weapon.MinDamageBonus;
            MaxDamage += negativeOrPositiveOne * weapon.MaxDamageBonus;
        }
        //To be used in equip, unequip armour methods
        public void ChangePlayerStatsEquipUnequipArmour(int negativeOrPositiveOne, Armour armour)
        {
            _maxHealth += negativeOrPositiveOne * armour.HealthBonus;
            HumanoidResistance += negativeOrPositiveOne * armour.HumanoidResistanceBonus;
            MysticalResistance += negativeOrPositiveOne * armour.MysticalResistanceBonus;
        }


        #endregion

        #region Helper Functions

        //Level up method
        private void LevelUp()
        {
            Level++;
            StatPoints += STAT_POINTS_PER_LEVEL;
            Health = MaxHealth;
            ExperienceNeededForLevelUp = CalculateExperienceNeededForNextLevel();
            MinDamage += MIN_DAMAGE_RECEIVED_PER_LEVEL;
            MaxDamage += MAX_DAMAGE_RECEIVED_PER_LEVEL;
        }

        //Provides int for experience needed for next level;
        private int CalculateExperienceNeededForNextLevel()
        {
            return (int)Math.Round((Level * EXPERIENCE_NEEDED_INCREASE_MARGIN ) + EXPERIENCE_NEEDED_INCREASE_BASE);
        }

        #endregion

        #region Game Changing Methods

        //Player dies, receives a message and has to go back to the Main Menu
        public void Die(string deathMessage)
        {
            DeathMessage = deathMessage;
            IsAlive = false;
        }

        public void TryAgainAfterDeath()
        {
            Health = MaxHealth;
            IsAlive = true;
            PlayerIsLocked = false;
            RuneActive = false;
            RuneNumberOfTurnsActive = 0;
            GoldDust -= GOLD_DUST_LOST_ON_DEATH_PER_LEVEL * Level;
            if (GoldDust < 0) GoldDust = 0;
        }        
        public void Flight()
        {
            GoldDust -= GOLD_DUST_LOST_ON_FLIGHT;
            PlayerIsLocked = false;
            RuneActive = false;
            RuneNumberOfTurnsActive = 0;
            if (GoldDust < 0) GoldDust = 0;
        }
        public void ExploreSuccessMethod()
        {
            GoldDust += GOLD_DUST_ON_EXPLORE_SUCCESS;
            ExploreSuccess = true;
            PlayerIsLocked = false;
            RuneActive = false;
            RuneNumberOfTurnsActive = 0;
            NewShadyDealerAvailable = true;
        }

        #endregion

    }
}

