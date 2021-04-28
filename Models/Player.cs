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
        #endregion


        #region Methods on Player Stats
        public void IncreaseHealth(double _healthAmount)
        {
            if(_healthAmount<=0)
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
