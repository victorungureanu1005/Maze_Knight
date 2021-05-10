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
        private EnemyTypes _enemyType;
        private int _enemyCount;

        #endregion

        #region Properties
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

        #endregion

    }
}
