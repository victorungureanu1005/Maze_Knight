using Maze_Knight.StaticClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models
{
    //Class to be instantiated in case map measure methods are needed
    public class MapMeasures
    {
        private const int MIN_COLUMN = 4;
        private const int MIN_ROW = 4;
        //GRID_EXPANSE_RATE has been set to 0.24 after testing to ensure that limits increase by 1 after 3rd lvl and then after ~ an increase by 4 of the level
        private const float GRID_EXPANSE_RATE = 0.24f;
        private Player player;
        public MapMeasures(Player player)
        {
            this.player = player;
        }
        //Get cell number of the grid
        public int GetMaxCellNumber()
        {
            return GetMaxRow() * GetMaxColumn();
        }

        //Get width of the grid
        public int GetMaxColumn()
        {
            int actualWidth = MIN_COLUMN + GetActualExpanseIncrease();
            return actualWidth;
        }

        //Get height of the grid
        public int GetMaxRow()
        {
            int actualHeight = MIN_ROW + GetActualExpanseIncrease();
            return actualHeight;
        }

        //Get increase of the width and height
        public int GetActualExpanseIncrease()
        {
            int actualExpanse = (int)(Math.Round(GRID_EXPANSE_RATE * player.Level));
            return actualExpanse;
        }
    }
}
