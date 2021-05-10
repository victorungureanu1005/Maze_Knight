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
        private int _level;
        private string _name;

        //Player Stats
        private double _health;
        private double _archerySkillLevel;
        private double _swordSkillLevel;
        private double _halberdSkillLevel;

        //Player Location
        private int[] _playerLocation;
        private MapGridCell _cellOfPlayerLocation;

        #endregion

        #region Generic Player Information Properties
        //Level of Player
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        //Name of Player
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion

        #region Player Stats Properties

        //Health of Player
        public double Health
        {
            get { return _health; }
        }

        //Archer Skill
        public double ArcherySillLevel
        {
            get { return _archerySkillLevel; }
            set { _archerySkillLevel = value; }
        }

        //Sword Skill
        public double SwordSkillLevel
        {
            get { return _swordSkillLevel; }
            set { _swordSkillLevel = value; }
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
        //Increase health of player
        public void IncreaseHealth(double _healthAmount)
        {
            if (_healthAmount <= 0)
                return;
            if (_healthAmount + _health <= 100)
                _health += _healthAmount;
            else _health = 100;
        }

        //Decrease health of player
        public void DecreaseHealth(double _healthAmount)
        {
            if (_healthAmount >= 0)
                return;
            if (_health - _healthAmount <= 0)
            {
                _health = 0;
                Die();
            }
            else _health -= _healthAmount;
        }

        #endregion

        #region Game Changing Methods
        //Player dies, receives a message and has to go back to the Main Menu
        private void Die()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
