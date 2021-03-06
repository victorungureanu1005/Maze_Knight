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
            MysticalCreaturesEnemies testTroll = new Trolls(5);
            var result = new Rogues(0) { EnemyCount = 3, EnemyHealth = 225, EnemySubType = Models.Enums.EnemySubTypes.Rogues };

            Assert.AreEqual(testDragon.HalberdResistance, 0.75F);

        }

    }
}

