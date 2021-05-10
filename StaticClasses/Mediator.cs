using Maze_Knight.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight
{
    //Mediator needed to keep track of current View and ViewModel to be effective
    public static class Mediator
    {
        public static AppWindowViewModel theApp = new AppWindowViewModel();
    }
}
