using Maze_Knight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.ViewModels
{
    //This class get's instantiated within the explore view model
    public class ShadyDealerViewModel : BaseViewModel
    {
       private ShadyDealerModel _shadyDealer;
       public ShadyDealerViewModel(Player player)
        {
            ShadyDealer = new ShadyDealerModel(player);
        }

        public ShadyDealerModel ShadyDealer { get => _shadyDealer; set => _shadyDealer = value; }
    }
}
