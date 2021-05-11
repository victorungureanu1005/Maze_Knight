using Maze_Knight.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models.EnemyModels
{
    public class MysticalCreaturesEnemies : Enemy
    {
        //Need to work on this
        MysticalCreaturesEnemies(int enemyCountValue) : base(enemyCountValue)
        {
            HalberdResistance = ((int)EnemyResistancesHalberd.MysticalCreatues)/100;
        }

        protected void InitMysticalCreaturesEnemy()
        {
            HalberdResistance = ((int)EnemyResistancesHalberd.MysticalCreatues)/100;
        }
        public class Goblins : MysticalCreaturesEnemies
        {
            #region Constructor
            public Goblins(int enemyCountValue) : base(enemyCountValue)
            {
                EnemyType = EnemyTypes.Goblins;
                EnemyHealth = (int)EnemyTypesHealth.Goblins * EnemyCount;
                InitMysticalCreaturesEnemy();
            }
            #endregion
        }

        public class Orcs : MysticalCreaturesEnemies
        {
            #region Constructor
            public Orcs(int enemyCountValue) : base(enemyCountValue)
            {
                EnemyType = EnemyTypes.Orcs;
                EnemyHealth = (int)EnemyTypesHealth.Orcs * EnemyCount;
                InitMysticalCreaturesEnemy();
            }
            #endregion
        }

        public class Trolls : MysticalCreaturesEnemies
        {
            #region Constructor
            public Trolls(int enemyCountValue) : base(enemyCountValue)
            {
                EnemyType = EnemyTypes.Trolls;
                EnemyHealth = (int)EnemyTypesHealth.Trolls * EnemyCount;
                InitMysticalCreaturesEnemy();
            }
            #endregion
        }

        public class Dragons : MysticalCreaturesEnemies
        {
            #region Constructor
            public Dragons(int enemyCountValue) : base(enemyCountValue)
            {
                EnemyType = EnemyTypes.Dragons;
                EnemyHealth = (int)EnemyTypesHealth.Dragons * EnemyCount;
                
            }
            #endregion
        }
    }
}
