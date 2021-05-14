using Maze_Knight.Models.Comparers;
using Maze_Knight.StaticClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models
{
    public class Player
    {
        #region Backing Fields
        //Generic Player information
        private string _name;
        private int _level;
        private int _goldDust;
        private int _currentExperience;
        private int _statPoints;


        //Player Stats
        private double _health = 100;
        private double _swordSkillLevel = 1 ;
        private double _archerySkillLevel = 2;
        private double _halberdSkillLevel = 3;

        //Player Location
        private int[] _playerLocation;
        private MapGridCell _cellOfPlayerLocation;

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
            set { _level = value; }
        }

        //Gold Dust of Player
        public int GoldDust
        {
            get { return _goldDust; }
            set { _goldDust = value; }
        }

        //Current Experience of Player
        public int CurrentExperience
        {
            get { return _currentExperience; }
            set { _currentExperience = value; }
        }

        //Statpoints of Player
        public int StatPoints
        {
            get { return _statPoints; }
            set { _statPoints = value; }
        }


        #endregion

        #region Player Stats Properties

        //Health of Player
        public double Health
        {
            get { return _health; }
            set { _health = value; }
        }

        //Sword Skill
        public double SwordSkillLevel
        {
            get { return _swordSkillLevel; }
            set { _swordSkillLevel = value; }
        }

        //Archer Skill
        public double ArcherySillLevel
        {
            get { return _archerySkillLevel; }
            set { _archerySkillLevel = value; }
        }

        //Halberd Skill
        public double HalberdSkillLevel
        {
            get { return _halberdSkillLevel; }
            set { _halberdSkillLevel = value; }
        }
        #endregion

        #region Player Location Propreties

        //Player Location on Map
        public int[] PlayerLocation
        {
            get { return _playerLocation; }
            set { _playerLocation = value; }
        }

        public MapGridCell CellOfPlayerLocation
        {
            get { return _cellOfPlayerLocation; }
            set { _cellOfPlayerLocation = value; }
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

        //Increase health of player
        public void IncreaseHealth(double healthAmount)
        {
            if (healthAmount <= 0)
                return;
            if (healthAmount + _health <= 100)
                _health += healthAmount;
            else _health = 100;
        }

        //Decrease health of player
        public void DecreaseHealth(double healthAmount)
        {
            if (healthAmount >= 0)
                return;
            if (_health - healthAmount <= 0)
            {
                _health = 0;
                Die();
            }
            else _health -= healthAmount;
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
            throw new Exception("YOU DIED!");
        }

        #endregion

    }
}

