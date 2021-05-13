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

            SetEnemiesAndExitOnMap(MapGridCellCollection);
        }
        #endregion

        private void SetEnemiesAndExitOnMap(ObservableCollection<MapGridCell> mapGridCellCollection)
        {
            //var cellCollectionReferenceDuplicate= mapGridCellCollection;
            int playerLevel = PlayerInstances.CurrentPlayerInstance.Level;
            HashSet<int> usedIndexes = new HashSet<int>();

            //setting Exit
            int exitIndex = SetExitOnMap(mapGridCellCollection.Count);
            MapGridCellCollection[exitIndex].ExitIsHere = true;
            usedIndexes.Add(exitIndex);

            //Setting enemies
            for (int i = 0; i < playerLevel; i++)
            {
                int indexer = RandomGenerator.random.Next(1, mapGridCellCollection.Count);
                while (usedIndexes.Contains(indexer)==true)
                {
                    indexer = RandomGenerator.random.Next(1, mapGridCellCollection.Count);
                }

                string enemyToInstantiateString = SetEnemyType();
                Type enemyToInstantiateType = Type.GetType(enemyToInstantiateString);
                mapGridCellCollection[indexer].Enemy = (Enemy)Activator.CreateInstance(enemyToInstantiateType, playerLevel);
                mapGridCellCollection[indexer].EnemyIsHere = true;
            }


        }
        private int SetExitOnMap(int maxCells)
        {
            return RandomGenerator.random.Next(1, maxCells);
        }

        private string SetEnemyType()
        {
            double random = RandomGenerator.random.NextDouble();
            if (random<0.3D)
            {
                return typeof(Rogues).AssemblyQualifiedName;
            }
            if (random<0.5D)
            {
                return typeof(ThievyArchers).AssemblyQualifiedName;
            }
            if (random<0.6D)
            {
                return typeof(Goblins).AssemblyQualifiedName;
            }
            if (random<0.75D)
            {
                return typeof(Orcs).AssemblyQualifiedName;
            }
            if (random<0.83D)
            {
                return typeof(CorruptPaladins).AssemblyQualifiedName;
            }
            if (random<0.90D)
            {
                return typeof(Trolls).AssemblyQualifiedName;
            }
            if (random<0.97D)
            {
                return typeof(CorruptMages).AssemblyQualifiedName;
            }
            if (random>=0.97D)
            {
                return typeof(Dragons).AssemblyQualifiedName;
            }

            else return typeof(Rogues).AssemblyQualifiedName;

        }
    }
}

