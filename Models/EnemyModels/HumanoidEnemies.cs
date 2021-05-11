using Maze_Knight.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models.EnemyModels
{
    public class HumanoidEnemies : Enemy
    {
        public HumanoidEnemies(int enemyCountValue) : base(enemyCountValue)
        {
        }

        void InitHumanoidEnemy()
        {
            HalberdResistance = (int)EnemyResistancesHalberd.HumanoidEnemies/100;
        }

        public class Rogues : HumanoidEnemies
        {

            #region Constructor
            public Rogues(int enemyCountValue) : base(enemyCountValue)
            {
                EnemyType = EnemyTypes.Rogues;
                EnemyHealth = (int)EnemyTypesHealth.Rogues * EnemyCount;
                InitHumanoidEnemy();
            }
            #endregion
        }

        public class ThievyArchers : HumanoidEnemies
        {
            #region Constructor
            public ThievyArchers(int enemyCountValue) : base(enemyCountValue)
            {
                EnemyType = EnemyTypes.ThievyArchers;
                EnemyHealth = (int)EnemyTypesHealth.ThievyArchers * EnemyCount;
                InitHumanoidEnemy();
            }
            #endregion
        }

        public class CorruptPaladins : HumanoidEnemies
        {
            #region Constructor
            public CorruptPaladins(int enemyCountValue) : base(enemyCountValue)
            {
                EnemyType = EnemyTypes.CorruptPaladins;
                EnemyHealth = (int)EnemyTypesHealth.CorruptPaladins * EnemyCount;
                InitHumanoidEnemy();
            }
            #endregion
        }

        public class CorruptMages : HumanoidEnemies
        {
            #region Constructor
            public CorruptMages(int enemyCountValue) : base(enemyCountValue)
            {
                EnemyType = EnemyTypes.CorruptMages;
                EnemyHealth = (int)EnemyTypesHealth.CorruptMages * EnemyCount;
                InitHumanoidEnemy();
            }
            #endregion
        }




    }
}
