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
        private const double PERCENTAGE_CREATOR = 100D;

        //Constructor to provide Halberd Resistance - this is grouped as per Enemy Subtype mystical or humanoid
        public HumanoidEnemies(int enemyCountValue) : base(enemyCountValue)
        {
            EnemyType = EnemyTypes.HumanoidEnemies;
            
            SwordResistance = (double)EnemyResistancesSword.HumanoidEnemies/PERCENTAGE_CREATOR;
            ArrowResistance = (double)EnemyResistancesArrow.HumanoidEnemies/PERCENTAGE_CREATOR;
            HalberdResistance = (double)EnemyResistancesHalberd.HumanoidEnemies/PERCENTAGE_CREATOR;
            RuneResistance = (double)EnemyResistancesRune.HumanoidEnemies/PERCENTAGE_CREATOR;
        }
    }
    public class Rogues : HumanoidEnemies
    {

        #region Constructor
        public Rogues(int enemyCountValue) : base(enemyCountValue)
        {
        }
        #endregion
    }

    public class ThievyArchers : HumanoidEnemies
    {
        #region Constructor
        public ThievyArchers(int enemyCountValue) : base(enemyCountValue)
        {
        }
        #endregion
    }

    public class CorruptPaladins : HumanoidEnemies
    {
        #region Constructor
        public CorruptPaladins(int enemyCountValue) : base(enemyCountValue)
        {
        }
        #endregion
    }

    public class CorruptMages : HumanoidEnemies
    {
        #region Constructor
        public CorruptMages(int enemyCountValue) : base(enemyCountValue)
        {
        }
        #endregion
    }




}

