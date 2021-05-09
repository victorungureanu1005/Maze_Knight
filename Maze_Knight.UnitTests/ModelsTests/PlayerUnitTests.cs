using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Maze_Knight.Models;
using Maze_Knight.Models.Comparers;

namespace Maze_Knight.UnitTests.ModelsTests
    {
        [TestClass]
        public class PlayerUnitTests
        {

            [TestMethod]
            public void GetMoveOptions_ObtainMoveOptions_CorrectMoveOptions()
            {
                //Comparer needed to check equality between HashSet containing move options/possible move options
                var _comparer = new CoordinatesEqualityComparer();

                //Scenario 1 where we have a small grid
                #region Scenario1
                var scenario1TestPlayerslvl1WithLocations = new List<Player>
            {
                //Corner Locations
                new Player {PlayerLocation = new int[] {0, 0}, Level = 1},
                new Player {PlayerLocation = new int[] {0, 3}, Level = 1},
                new Player {PlayerLocation = new int[] {3, 0}, Level = 1},
                new Player {PlayerLocation = new int[] {3, 3}, Level = 1},
                //Border Locations
                new Player {PlayerLocation = new int[] {1, 0}, Level = 1},
                new Player {PlayerLocation = new int[] {0, 1}, Level = 1},
                new Player {PlayerLocation = new int[] {2, 3}, Level = 1},
                new Player {PlayerLocation = new int[] {3, 2}, Level = 1},
                //Center Locations
                new Player {PlayerLocation = new int[] {1, 1}, Level = 1},
                new Player {PlayerLocation = new int[] {2, 1}, Level = 1},
            };

                var scenario1ExpectedResults = new List<HashSet<List<int>>>
            {
                //CornerLocations 
                new HashSet<List<int>> (_comparer) { new List<int> {0, 1}, new List<int> { 1, 0} },
                new HashSet<List<int>> (_comparer) { new List<int> {0, 2}, new List<int> { 1, 3} },
                new HashSet<List<int>> (_comparer) { new List<int> {3, 1}, new List<int> {2, 0} },
                new HashSet<List<int>> (_comparer) { new List<int> {3, 2}, new List<int> {2, 3} },
                //Border Locations                                
                new HashSet<List<int>> (_comparer) { new List<int> {0, 0}, new List<int> {1, 1}, new List<int> {2, 0} },
                new HashSet<List<int>> (_comparer) { new List<int> {0, 0}, new List<int> {0, 2}, new List<int> {1, 1} },
                new HashSet<List<int>> (_comparer) { new List<int> {2, 2}, new List<int> {1, 3}, new List<int> {3, 3} },
                new HashSet<List<int>> (_comparer) { new List<int> {3, 1}, new List<int> {2, 2}, new List<int> {3, 3} },
                //Center Locations                                                        
                new HashSet<List<int>> (_comparer) { new List<int> {1, 0}, new List<int> {1, 2}, new List<int> {0, 1}, new List<int> {2, 1} },
                new HashSet<List<int>> (_comparer) { new List<int> {2, 0}, new List<int> {2, 2}, new List<int> {1, 1}, new List<int> {3, 1} },
            };

                //Getting actual results for scenario1
                var scenario1ActualResults = new List<HashSet<List<int>>>();
                foreach (var item in scenario1TestPlayerslvl1WithLocations)
                {
                    scenario1ActualResults.Add(item.GetMoveOptions());
                }
                #endregion

                //Scenario 2 where we have bigger grids
                #region Scenario2
                var scenario2TestPlayersWithLocations = new List<Player>
            {
                //Corner Locations
                new Player {PlayerLocation = new int[] {0, 0}, Level = 11},
                new Player {PlayerLocation = new int[] {0, 8}, Level = 20},
                new Player {PlayerLocation = new int[] {6, 0}, Level = 11},
                new Player {PlayerLocation = new int[] {8, 8}, Level = 20},
                //Border Locations
                new Player {PlayerLocation = new int[] {1, 0}, Level = 7},
                new Player {PlayerLocation = new int[] {0, 1}, Level = 8},
                new Player {PlayerLocation = new int[] {2, 5}, Level = 9},
                new Player {PlayerLocation = new int[] {5, 2}, Level = 10},
                //Center Locations
                new Player {PlayerLocation = new int[] {1, 1}, Level = 13},
                new Player {PlayerLocation = new int[] {2, 1}, Level = 14},
            };

                var scenario2ExpectedResults = new List<HashSet<List<int>>>
            {
                //CornerLocations
                new HashSet<List<int>> (_comparer) { new List<int> {0, 1}, new List<int> { 1, 0} },
                new HashSet<List<int>> (_comparer) { new List<int> {0, 7}, new List<int> { 1, 8} },
                new HashSet<List<int>> (_comparer) { new List<int> {6, 1}, new List<int> {5, 0} },
                new HashSet<List<int>> (_comparer) { new List<int> {8, 7}, new List<int> {7, 8} },
                //Border Locations                                
                new HashSet<List<int>> (_comparer) { new List<int> {0, 0}, new List<int> {1, 1}, new List<int> {2, 0} },
                new HashSet<List<int>> (_comparer) { new List<int> {0, 0}, new List<int> {0, 2}, new List<int> {1, 1} },
                new HashSet<List<int>> (_comparer) { new List<int> {2, 4}, new List<int> {1, 5}, new List<int> {3, 5} },
                new HashSet<List<int>> (_comparer) { new List<int> {5, 1}, new List<int> {4, 2}, new List<int> {5, 3} },
                //Center Locations                                                        
                new HashSet<List<int>> (_comparer) { new List<int> {1, 0}, new List<int> {1, 2}, new List<int> {0, 1}, new List<int> {2, 1} },
                new HashSet<List<int>> (_comparer) { new List<int> {2, 0}, new List<int> {2, 2}, new List<int> {1, 1}, new List<int> {3, 1} },
            };

                //Getting actual results for scenario1
                var scenario2ActualResults = new List<HashSet<List<int>>>();
                foreach (var item in scenario2TestPlayersWithLocations)
                {
                    scenario2ActualResults.Add(item.GetMoveOptions());
                }
                #endregion

                #region Assertions
                //Go Through each created HashSet contained in the scenario specific lists and compare with related HashSets in method created lists

                for (int i = 0; i < scenario1ExpectedResults.Count; i++)
                {
                    Assert.IsTrue(scenario1ExpectedResults[i].SetEquals(scenario1ActualResults[i]));
                }

                for (int i = 0; i < scenario2ExpectedResults.Count; i++)
                {
                    Assert.IsTrue(scenario2ExpectedResults[i].SetEquals(scenario2ActualResults[i]));
                }
                #endregion
            }

        }
    }

