using Maze_Knight.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models
{
    public class Enemy : BaseModel
    {
        #region Backing Fields

        //Generic Properties
        private EnemyTypes _enemyType;
        private int _enemyCount;
        private int _enemyHealth;

        //Resistance Properties
        private float _swordResistance;
        private float _arrowResistance;
        private float _halberdResistance;
        private float _runeResistance;

        #endregion

        #region Generic Properties
        //Enemy type as per enum
        public EnemyTypes EnemyType
        {
            get { return _enemyType; }
            set { _enemyType = value; }
        }

        //number of enemies on the specified grid cell
        public int EnemyCount
        {
            get { return _enemyCount; }
            set { _enemyCount = value; }
        }

        //Health of 1 Enemy
        public int EnemyHealth
        {
            get { return _enemyHealth; }
            set { _enemyHealth = value; }
        }

        #endregion

        #region Resistance Properties

        public float SwordResistance
        {
            get { return _swordResistance; }
            set { _swordResistance = value; }
        }
        public float ArrowResistance
        {
            get { return _arrowResistance; }
            set { _arrowResistance = value; }
        }
        public float HalberdResistance
        {
            get { return _halberdResistance; }
            set { _halberdResistance = value; }
        }
        public float RuneResistance
        {
            get { return _runeResistance; }
            set { _runeResistance = value; }
        }
        #endregion

        #region Base Class Constructor
        public Enemy(int enemyCountValue)
        {
            EnemyCount = enemyCountValue;
        }

        #endregion
    }
}
