using Maze_Knight.Models.EnemyModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static Maze_Knight.Models.EnemyModels.HumanoidEnemies;
using static Maze_Knight.Models.EnemyModels.MysticalCreaturesEnemies;

namespace Maze_Knight.UnitTests.ModelsTests
{
    [TestClass]
    public class EnemyUnitTests
    {
        [TestMethod]
        public void Rogues_Constructor_CorrectlyConstructed()
        {
            Rogues testRogue = new Rogues(3);
            MysticalCreaturesEnemies testDragon = new Dragons(2);

            var result = new Rogues(0) { EnemyCount = 3, EnemyHealth = 225, EnemyType = Models.Enums.EnemyTypes.Rogues };

            Assert.AreEqual(testDragon.HalberdResistance, 0.75F);

        }

    }
}

