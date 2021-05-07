using Maze_Knight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.StaticClasses
{
    public static class PlayerInstances

    {
        public static Player CurrentPlayerInstance = new Player() { Level = 1 };
    }
}
