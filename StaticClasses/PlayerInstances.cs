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
        //Current Player object
        public static Player CurrentPlayerInstance = new Player() { Level = 20, GoldDust = 3000, StatPoints=100, BowSkillLevel=100};
        //Current available ShadyDealerViewModel for the Current Player
        public static ShadyDealerViewModel CurrentPlayerAvailableShadyDealerViewModel;












    }
}
