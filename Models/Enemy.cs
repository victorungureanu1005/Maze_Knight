using Maze_Knight.Models.EnemyModels;
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
        private EnemySubTypes _enemySubType;
        private int _enemyCount;
        private int _enemyHealth;
        private bool _isAlive;
        private int _minDamage;
        private int _maxDamage;
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

        //Enemy subtype as per enum
        public EnemySubTypes EnemySubType
        {
            get { return _enemySubType; }
            set { _enemySubType = value; }
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

        //Is Alive boolean
        public bool IsAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
        }

        //Min Damage dealth with all weapons
        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value; }
        }

        //Max Damage dealth with all weapons
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
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
            IsAlive = true;


            //EnemySubType
            //Get the name of the instantiated class and relate it to its enum for the enemy subtype - set the property accordingly
            EnemySubTypes enemyTypesEnum;
            Enum.TryParse(this.GetType().Name, out enemyTypesEnum);
            EnemySubType = enemyTypesEnum;

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

            //EnemyMinDamage
            //Get the name of the instantiated class and relate it to its enum for MinDamage - set the property accordingly
            EnemyMinDamage enemyMinDamage;
            Enum.TryParse(this.GetType().Name, out enemyMinDamage);
            MinDamage = (int)enemyMinDamage * EnemyCount;

            //EnemyMaxDamage
            //Get the name of the instantiated class and relate it to its enum for MaxDamage - set the property accordingly
            EnemyMaxDamage enemyMaxDamage;
            Enum.TryParse(this.GetType().Name, out enemyMaxDamage);
            MaxDamage = (int)enemyMaxDamage * EnemyCount;
        }

        #endregion

        #region Main Methods

        //Increase health
        public void IncreaseHealth(int healthAmount)
        {
            if (healthAmount <= 0)
                return;
            if (healthAmount + EnemyHealth <= 100)
                EnemyHealth += healthAmount;
            else EnemyHealth = 100;
        }

        //Decrease health
        public void DecreaseHealth(int healthAmount)
        {
            if (healthAmount <= 0)
                return;
            if (EnemyHealth - healthAmount <= 0)
            {
                EnemyHealth = 0;
                Die();
            }
            else EnemyHealth -= healthAmount;
        }

        public void Die()
        {
            IsAlive = false;
            Console.WriteLine("Enemy Died");
        }
        #endregion
    }
}
