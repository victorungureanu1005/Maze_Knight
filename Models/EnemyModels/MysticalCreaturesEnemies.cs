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
        public class Goblins : MysticalCreaturesEnemies
        {
            #region Constructor
            public Goblins()
            {
                EnemyType = EnemyTypes.Goblins;
            }
            #endregion
        }

        public class Orcs : MysticalCreaturesEnemies
        {
            #region Constructor
            public Orcs()
            {
                EnemyType = EnemyTypes.Orcs;
            }
            #endregion
        }

        public class Trolls : MysticalCreaturesEnemies
        {
            #region Constructor
            public Trolls()
            {
                EnemyType = EnemyTypes.Trolls;
            }
            #endregion
        }

        public class Dragons : MysticalCreaturesEnemies
        {
            #region Constructor
            public Dragons()
            {
                EnemyType = EnemyTypes.Dragons;
            }
            #endregion
        }
    }
}
