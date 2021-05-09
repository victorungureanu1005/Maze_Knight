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
        #region Generic Player Information
        //Level of Player
        private int _level;
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        //Name of Player
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion
        #region Player Stats

        //Health of Player
        private double _health;
        public double Health
        {
            get { return _health; }
        }

        //Archer Skill
        private double _archerySkillLevel;
        public double ArcherySillLevel
        {
            get { return _archerySkillLevel; }
            set { _archerySkillLevel = value; }
        }

        //Sword Skill
        private double _swordSkillLevel;
        public double SwordSkillLevel
        {
            get { return _swordSkillLevel; }
            set { _swordSkillLevel = value; }
        }

        //Halberd Skill
        private double _halberdSkillLevel;
        public double HalberdSkillLevel
        {
            get { return _halberdSkillLevel; }
            set { _halberdSkillLevel = value; }
        }

        //Player Location on Map
        private int[] _playerLocation;

        public int[] PlayerLocation
        {
            get { return _playerLocation; }
            set { _playerLocation = value; }
        }

        #endregion


        #region Methods on Player Stats

        // De testat si poate bagat in ExploreviewModel?
        public HashSet<int[]> GetMoveOptions()
        {
            //Getting current location and storing the column and row number
            int[] _currentPlayerLocation = PlayerInstances.CurrentPlayerInstance.PlayerLocation;
            int column = _currentPlayerLocation[0];
            int row = _currentPlayerLocation[1];
            //Creating a new HashSet which will be updated and returned
            HashSet<int[]> _moveOptions = new HashSet<int[]>();

            //Start creating the options, player can only move in cross directions 1 step at a time, not outside of bounds
            //Checking first the left and upper bounds (column and row should not be less than 0) and adding the options to the HashSet
            if (column - 1 < 0)
            {
                if (row - 1 < 0)
                {
                    _moveOptions.Add(new int[] { column + 1, row });
                    _moveOptions.Add(new int[] { column, row + 1 });
                }
                else
                {
                    _moveOptions.Add(new int[] { column + 1, row });
                    _moveOptions.Add(new int[] { column, row + 1 });
                    _moveOptions.Add(new int[] { column, row - 1 });
                }
            }
            else
            {
                _moveOptions.Add(new int[] { column + 1, row });
                _moveOptions.Add(new int[] { column, row + 1 });
                _moveOptions.Add(new int[] { column, row - 1 });
                _moveOptions.Add(new int[] { column - 1, row - 1 });
            }
            
            //!!!Daca mut asta in ExploreViewModel nu mai e nevoie sa instantiez MapMeasures!!!
            MapMeasures _mapMeasures = new MapMeasures();

            //Checking then from the existing options whether options go out of bounds, checking right and bottom bounds ([0] - column; [1] - row)
            foreach (int[] item in _moveOptions)
            {
                if (item[0] > _mapMeasures.GetMaxColumn())
                {
                    _moveOptions.Remove(item);
                }
                if (item[1] > _mapMeasures.GetMaxRow())
                {
                    _moveOptions.Remove(item);
                }
            }

            return _moveOptions;
        }



        public void IncreaseHealth(double _healthAmount)
        {
            if (_healthAmount <= 0)
                return;
            if (_healthAmount + _health <= 100)
                _health += _healthAmount;
            else _health = 100;
        }

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
