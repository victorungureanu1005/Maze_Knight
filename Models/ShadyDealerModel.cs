using Maze_Knight.Models.Items;
using Maze_Knight.StaticClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models
{
    public class ShadyDealerModel
    {
        #region Constants
        private const int MAX_WEAPON_OFFERS = 2;
        private const int MAX_ARMOUR_OFFERS = 3;
        private const int MAX_POTION_OFFERS = 2;
        private const int MAX_RUNE_OFFERS = 1;
        #endregion
        #region Backing Fields
        private Inventory _shadyDealerInventory;
        private int _currentPlayerLevel;
        #endregion

        #region Constructor
        public ShadyDealerModel(Player player)
        {
            CurrentPlayerLevel = player.Level;
            ShadyDealerInventory = new Inventory();
            ShadyDealerInventory.InventoryCapacity = 8;
            GenerateOffer();
        }
        #endregion

        #region Properties
        public Inventory ShadyDealerInventory { get => _shadyDealerInventory; set => _shadyDealerInventory = value; }
        public int CurrentPlayerLevel { get => _currentPlayerLevel; set => _currentPlayerLevel = value; }
        #endregion

        #region Main Method
        private void GenerateOffer()
        {
            GenerateWeaponOffer();
            GenerateArmourOffer();
            GeneratePotionOffer();
            GenerateRuneOffer();
        }
        #endregion

        #region Helper Functions
        private void GenerateWeaponOffer()
        {
            for (int i = 0; i < MAX_WEAPON_OFFERS; i++)
            {
                //Generate a random type of weapon
                int randomWeaponToGenerate = (int)RandomGenerator.random.Next(0, 3);
                switch (randomWeaponToGenerate)
                {
                    case 0: ShadyDealerInventory.InventoryCollection.Add(new Sword()); break;
                    case 1: ShadyDealerInventory.InventoryCollection.Add(new Bow()); break;
                    case 2: ShadyDealerInventory.InventoryCollection.Add(new Halberd()); break;

                }
            }
        }
        private void GenerateArmourOffer()
        {
            for (int i = 0; i < MAX_ARMOUR_OFFERS; i++)
            {
                ShadyDealerInventory.InventoryCollection.Add(new Armour());
            }
        }
        private void GeneratePotionOffer()
        {
            for (int i = 0; i < MAX_POTION_OFFERS; i++)
            {
                ShadyDealerInventory.InventoryCollection.Add(new Potion());
            }
        }
        private void GenerateRuneOffer()
        {
            for (int i = 0; i < MAX_RUNE_OFFERS; i++)
            {
                ShadyDealerInventory.InventoryCollection.Add(new Rune());
            }
        }
        #endregion

    }
}
