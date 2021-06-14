using Maze_Knight.Commands.SaveLoadSystem;
using Maze_Knight.Models.Items;
using Maze_Knight.StaticClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Maze_Knight.ViewModels
{
    public class TownViewModel : BaseViewModel
    {
        #region Backing Fields
        //Backing Field for the shady dealer
        private ShadyDealerViewModel _shadyDealerViewModel;
        #endregion

        public ICommand SaveGameCommand { get; set; }

        #region Constructor
        public TownViewModel()
        {
            //Check whether new shady dealer inventory can be generated and depending on that it does that
            ShadyDealerMethod();

            //Initialize Command
            SaveGameCommand = new SaveGameCommand();
        }
        #endregion

        #region Properties
        //Shady dealer view model property
        public ShadyDealerViewModel ShadyDealerViewModel
        {
            get { return _shadyDealerViewModel; }
            set
            {
                _shadyDealerViewModel = value;
                OnPropertyChanged(nameof(ShadyDealerViewModel));
            }
        }
        #endregion

        #region Methods
        //Shady Dealer method checks whether a new inventory can be generated or not. Links to be observed are
        //The bool stored in the current player static class and the stored static instantiation of the ShadyDealerInstance
        private void ShadyDealerMethod()
        {
            if (PlayerInstances.CurrentPlayerInstance.NewShadyDealerAvailable == true)
            {
                ShadyDealerViewModel = new ShadyDealerViewModel(PlayerInstances.CurrentPlayerInstance);
                PlayerInstances.CurrentPlayerAvailableShadyDealerViewModel = ShadyDealerViewModel;
                PlayerInstances.CurrentPlayerInstance.NewShadyDealerAvailable = false;
            }
            else
            {
                ShadyDealerViewModel = PlayerInstances.CurrentPlayerAvailableShadyDealerViewModel;
            }
        }
        #endregion
    }
}
