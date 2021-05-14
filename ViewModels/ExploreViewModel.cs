using Maze_Knight.Models;
using Maze_Knight.Models.EnemyModels;
using Maze_Knight.Models.Enums;
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
using System.Reflection;
using static Maze_Knight.Models.EnemyModels.MysticalCreaturesEnemies;

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

            //Setting Enemies and Exit Propreties on the MapGridCells found on the MapGridCellCollection
            SetEnemiesAndExitOnMap(MapGridCellCollection);
        }
        #endregion

        private void SetEnemiesAndExitOnMap(ObservableCollection<MapGridCell> mapGridCellCollection)
        {
            //var cellCollectionReferenceDuplicate= mapGridCellCollection;
            int playerLevel = PlayerInstances.CurrentPlayerInstance.Level;

            //HashSet of usedIndexes of mapGridCellCollection is needed to avoid player, enemies and exit to be instantiated on the same map grid cell
            HashSet<int> usedIndexes = new HashSet<int>();

            //setting Exit
            int exitIndex = SetExitOnMap(mapGridCellCollection.Count);
            MapGridCellCollection[exitIndex].ExitIsHere = true;
            usedIndexes.Add(exitIndex);

            //Setting enemies maximum of enemies on map is set to playerlevel
            for (int i = 0; i < playerLevel; i++)
            {
                //Minimum set to 1 as to avoid enemy to be on the first cell (0,0)
                int index = RandomGenerator.random.Next(1, mapGridCellCollection.Count);
                //If index is already in use, find a new one
                while (usedIndexes.Contains(index)==true)
                {
                    index = RandomGenerator.random.Next(1, mapGridCellCollection.Count);
                }

                //!!!
                //BELLOW TO BE CHANGED POSSIBLY - needs testing
                //!!!
                //Enemy Instantiation and provide number of enemies to be relative to playerlevel
                string enemyToInstantiateString = SetEnemyType(playerLevel);
                //Find enemytype/ class to be instantiated considering helper method below and instantiate on given index
                Type enemyToInstantiateType = Type.GetType(enemyToInstantiateString);
                mapGridCellCollection[index].Enemy = (Enemy)Activator.CreateInstance(enemyToInstantiateType, playerLevel);
                mapGridCellCollection[index].EnemyIsHere = true;
            }


        }

        #region Helper Methods
        /// <summary>
        /// Setting Exit on a specific index of the Observablecollection related to MapGridCells
        /// </summary>
        /// <param name="maxCells">Count of Cells in the Observable Collection</param>
        /// <returns></returns>
        private int SetExitOnMap(int maxCells)
        {
            //Minimum set to 1 as to avoid exit to be on the first cell (0,0)
            return RandomGenerator.random.Next(1, maxCells);
        }

        /// <summary>
        /// Obtain string needed for Activator.CreateInstance for random enemy creation invoked in the SetEnemy in Map method above
        /// </summary>
        /// <param name="playerLevel">playerlevel as it is relevant to establish enemy types - need to increase difficulty gradually</param>
        /// <returns>a string related to enemy class depending on type</returns>
        private string SetEnemyType(int playerLevel)
        {
            //random generated random number
            double random = RandomGenerator.random.NextDouble();

            //If player level <=5 enemy types can only be Rogues and ThievyArchers
            if (random<0.3D)
            {
                return typeof(Rogues).AssemblyQualifiedName;
            }
            if (random<0.5D)
            {
                return typeof(ThievyArchers).AssemblyQualifiedName;
            }
            else if (playerLevel<=5)
            {
                return typeof(Rogues).AssemblyQualifiedName;
            }

            //If player level <=10 enemy types can only be Rogues, ThievyArchers, Goblins and Orcs
            if (random<0.6D)
            {
                return typeof(Goblins).AssemblyQualifiedName;
            }
            if (random<0.75D)
            {
                return typeof(Orcs).AssemblyQualifiedName;
            }
            else if (playerLevel<=10)
            {
                if (random<0.94) return typeof(Goblins).AssemblyQualifiedName;
                if (random>=0.94) return typeof(Rogues).AssemblyQualifiedName;
            }

            //If player level <=15 enemy types can only be Rogues, ThievyArchers, Goblins, Orcs, CorruptPaladins and Trolls
            if (random<0.83D)
            {
                return typeof(CorruptPaladins).AssemblyQualifiedName;
            }
            if (random<0.90D)
            {
                return typeof(Trolls).AssemblyQualifiedName;
            }
            else if (playerLevel<=15)
            {
                if (random<0.935) return typeof(ThievyArchers).AssemblyQualifiedName;
                if (random>=0.978) return typeof(Orcs).AssemblyQualifiedName;
                if (random>=0.94) return typeof(Trolls).AssemblyQualifiedName;
            }

            //If player level above 15, all enemy types can be selected
            if (random<0.97D)
            {
                return typeof(CorruptMages).AssemblyQualifiedName;
            }
            if (random>=0.97D)
            {
                return typeof(Dragons).AssemblyQualifiedName;
            }

            //default inserted below
            else return typeof(Rogues).AssemblyQualifiedName;

        }

        #endregion
    }
}

