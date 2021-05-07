using Maze_Knight.Models;
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


        #region Propreties

        //private field for the MapGridCellCollection
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

        //Constructor of the Grid, Task Run is kept for testing purposes. 

        public ExploreViewModel()
        {
            //Intrebare
            // Ar trebui sa obtin deja masurile la initializare sau sa folosesc call de fiecare data? Stocare vs. Procesare?
            //Intrebare

            MapMeasures mapMeasures = new MapMeasures();


            #region GridCreationInViewModel
            //The MapGridCells must be added to the collection! - logic to be implemented
            for (int i = 0; i < mapMeasures.GetMaxCellNumber(); i++)
            {
                MapGridCellCollection.Add(new MapGridCell { WhatIsContained = $"{i}" });
            }
            #endregion

            #region TaskRunnerForTest
            //The below to only be used if Tests need to be implemented

            Task.Run(async () =>
            {
                int j = 0;
                while (true)
                {
                    await Task.Delay(300);
                    MapGridCellCollection[0].WhatIsContained += j;
                    j++;
                }
            });

            #endregion
        }
    }
}

