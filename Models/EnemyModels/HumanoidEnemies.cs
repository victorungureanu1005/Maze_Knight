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

        public class Rogues : HumanoidEnemies
        {
            #region Constructor
            public Rogues()
            {
                EnemyType = EnemyTypes.Rogues;
            }
            #endregion
        }

        public class ThievyArchers : HumanoidEnemies
        {
            #region Constructor
            public ThievyArchers()
            {
                EnemyType = EnemyTypes.ThievyArchers;
                            }
            #endregion
        }

        public class CorruptPaladins : HumanoidEnemies
        {
            #region Constructor
            public CorruptPaladins()
            {
                EnemyType = EnemyTypes.CorruptPaladins;
            }
            #endregion
        }

        public class CorruptMages : HumanoidEnemies
        {
            #region Constructor
            public CorruptMages()
            {
                EnemyType = EnemyTypes.CorruptMages;
            }
            #endregion
        }




    }
}
