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
        private const double PERCENTAGE_CREATOR = 100D;

        public MysticalCreaturesEnemies(int enemyCountValue) : base(enemyCountValue)
        {
            SwordResistance = ((double)EnemyResistancesSword.MysticalCreatues)/PERCENTAGE_CREATOR;
            ArrowResistance = ((double)EnemyResistancesArrow.MysticalCreatues)/PERCENTAGE_CREATOR;
            HalberdResistance = ((double)EnemyResistancesHalberd.MysticalCreatues)/PERCENTAGE_CREATOR;
            RuneResistance = ((double)EnemyResistancesRune.MysticalCreatues)/PERCENTAGE_CREATOR;
        }

        public class Goblins : MysticalCreaturesEnemies
        {
            #region Constructor
            public Goblins(int enemyCountValue) : base(enemyCountValue)
            {
                EnemyType = EnemyTypes.Goblins;
                EnemyHealth = (int)EnemyTypesHealth.Goblins * EnemyCount;

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
