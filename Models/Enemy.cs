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
        private int _goldDustDrop;
        private int _enemyExperienceGiven;

        //Resistance Properties
        private double _swordResistance;
        private double _arrowResistance;
        private double _halberdResistance;
        private double _runeResistance;

        //Fight Relevance Properties
        private bool _attackFirst = false;

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

        //Drop Amount
        public int GoldDustDrop
        {
            get { return _goldDustDrop; }
            set { _goldDustDrop = value; }
        }
        public int EnemyExperienceGiven
        {
            get { return _enemyExperienceGiven; }
            set { _enemyExperienceGiven = value; }
        }

        #endregion

        #region Resistance Properties

        public double SwordResistance
        {
            get { return _swordResistance; }
            set { _swordResistance = value; }
        }
        public double ArrowResistance
        {
            get { return _arrowResistance; }
            set { _arrowResistance = value; }
        }
        public double HalberdResistance
        {
            get { return _halberdResistance; }
            set { _halberdResistance = value; }
        }
        public double RuneResistance
        {
            get { return _runeResistance; }
            set { _runeResistance = value; }
        }
        #endregion

        #region Fight Relevance Properties

        //to be worked on
        public bool AttackFirst
        {
            get { return _attackFirst; }
            set { _attackFirst = value; }
        }

        #endregion

        #region Base Class Constructor
        public Enemy(int enemyCountValue)
        {
            EnemyCount = enemyCountValue;

            //EnemyType
            //Get the name of the instantiated class and relate it to its enum for the enemy type - set the property accordingly
            EnemyTypes enemyTypesEnum;
            Enum.TryParse(this.GetType().Name, out enemyTypesEnum);
            EnemyType = enemyTypesEnum;

            //GoldDustDrop
            //Get the name of the instantiated class and relate it to its enum for gold dust drop - set the property accordingly
            EnemyGoldDustDrop goldDustDropEnum;
            Enum.TryParse(this.GetType().Name, out goldDustDropEnum);
            GoldDustDrop = (int)goldDustDropEnum * EnemyCount;

            //EnemyExperienceGiven
            //Get the name of the instantiated class and relate it to its enum for experience given - set the property accordingly
            EnemyExperienceGiven experienceGivenEnum;
            Enum.TryParse(this.GetType().Name, out experienceGivenEnum);
            EnemyExperienceGiven = (int)experienceGivenEnum * EnemyCount;

            //EnemyHealth
            //Get the name of the instantiated class and relate it to its enum for health - set the property accordingly
            EnemyTypesHealth enemyTypesHealthEnum;
            Enum.TryParse(this.GetType().Name, out enemyTypesHealthEnum);
            EnemyHealth = (int)enemyTypesHealthEnum * EnemyCount;
        }

        #endregion
    }
}
