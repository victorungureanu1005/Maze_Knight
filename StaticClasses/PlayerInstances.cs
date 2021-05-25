using Maze_Knight.Models;
using Maze_Knight.ViewModels;
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
        //Store Player information
        public static Player CurrentPlayerInstance = new Player() { Level = 7};
        //Store shady dealer information
        public static ShadyDealerViewModel AvailableShadyDealerViewModel;
    }
}
