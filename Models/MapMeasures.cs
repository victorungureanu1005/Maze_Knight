using Maze_Knight.StaticClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models
{
    public class MapMeasures
    {
        private const int MIN_WIDTH = 4;
        private const int MIN_HEIGHT = 4;
        //GRID_EXPANSE_RATE has been set to 0.24 after testing to ensure that limits increase by 1 after 3rd lvl and then after ~ an increase by 4 of the level
        private const float GRID_EXPANSE_RATE = 0.24f;

        //Get cell number of the grid
        public int GetMaxCellNumber()
        {
            return GetHeight() * GetWidth();
        }

        //Get width of the grid
        public int GetWidth()
        {
            int actualWidth = MIN_WIDTH + GetActualExpanseIncrease();
            return actualWidth;
        }

        //Get height of the grid
        public int GetHeight()
        {
            int actualHeight = MIN_HEIGHT + GetActualExpanseIncrease();
            return actualHeight;
        }

        //Get increase of the width and height
        public int GetActualExpanseIncrease()
        {
            int actualExpanse = (int)(Math.Round(GRID_EXPANSE_RATE * PlayerInstances.CurrentPlayerInstance.Level));
            return actualExpanse;
        }
    }
}
