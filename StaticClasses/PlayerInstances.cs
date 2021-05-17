using Maze_Knight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Maze_Knight.StaticClasses
{
    //Static class to keep track of the player isntance
    public static class PlayerInstances
    {
        public static Player CurrentPlayerInstance = new Player() { Level = 25 };
    }
}
