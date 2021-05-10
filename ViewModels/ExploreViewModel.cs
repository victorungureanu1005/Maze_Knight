using Maze_Knight.Models;
using Maze_Knight.StaticClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;


namespace Maze_Knight.ViewModels
{
    public class ExploreViewModel : BaseViewModel
    {
        #region Properties
        //Backing Field for the MapGridCellCollection
        private ObservableCollection<MapGridCell> _mapGridCellCollection = new ObservableCollection<MapGridCell>();

        //property MapGridCellCollection to be linked to the View - ExploreView
        public ObservableCollection<MapGridCell> MapGridCellCollection
        {
            get { return _mapGridCellCollection; }
            set
            {
                _mapGridCellCollection = value;
                OnPropertyChanged(nameof(MapGridCellCollection));
            }
        }
        #endregion

        #region Constructor
        public ExploreViewModel()
        {
            //Needed for below GridCreationInViewModel
            MapMeasures mapMeasures = new MapMeasures(PlayerInstances.CurrentPlayerInstance);

            //Initialize PlayerLocation to 0,0 at the creation of the map
            PlayerInstances.CurrentPlayerInstance.PlayerLocation = new int[] { 0, 0 };

            //Below: Grid Creation in ViewModel
            //The MapGridCells must be added to the collection! - logic to be implemented
            for (int i = 0; i < mapMeasures.GetMaxColumn(); i++)
            {
                for (int j = 0; j<mapMeasures.GetMaxRow(); j++)
                {
                    MapGridCellCollection.Add(new MapGridCell() { CellColumnNumber = i, CellRowNumber = j });
                }
            }

            //Initializing hero on first cell after grid creation in view model
            MapGridCellCollection[0].PlayerIsHere = true;
            MapGridCellCollection[0].WasExplored = true;
            PlayerInstances.CurrentPlayerInstance.CellOfPlayerLocation = MapGridCellCollection[0];
        }
        #endregion
    }
}

