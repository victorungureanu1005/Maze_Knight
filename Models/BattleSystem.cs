using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models
{
    public class BattleSystem
    {
        #region ClassFields
        private Player currentPlayer;
        private Enemy enemyEngaged;
        #endregion

        #region Constructor
        //Constructor taking in player instance and enemy instance
        public BattleSystem(Player currentPlayer, Enemy enemyEngaged)
        {
            this.currentPlayer = currentPlayer;
            this.enemyEngaged = enemyEngaged;
        }
        #endregion

        #region Main Methods
        //Calculate Battle
        public void Battle()
        {

        }

        //Battle actions if won
        public void BattleResultIfWon()
        {

        }

        //Battle actions if lost
        public void BattleResultIfLost()
        {

        }

        #endregion

        #region Helper Functions

        #endregion




    }
}
