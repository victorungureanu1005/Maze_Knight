using Maze_Knight.Models.Enums.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze_Knight.Models.Enums.Items.Weapons;
using Maze_Knight.StaticClasses;

namespace Maze_Knight.Models.Items
{
    public class Bow : Weapon
    {
        public Bow() : base()
        {
            //Setting item types necessary for image binding on inventories and shady dealer
            ItemType = ItemTypes.Bow;
            SetBowSubType();
            //Set name of weapon after subtype has been given
            SetWeaponName();
        }
        private void SetBowSubType()
        {
            //Set random Weapon SubType from specific range depending on level. 
            if (PlayerLevelWhenGenerated <= 6)
            {
                WeaponSubType = (WeaponSubTypes)(RandomGenerator.random.Next(6, 8));
                return;
            }
            if (PlayerLevelWhenGenerated <= 12)
            {
                WeaponSubType = (WeaponSubTypes)(RandomGenerator.random.Next(8, 10));
                return;
            }
            if (PlayerLevelWhenGenerated > 12)
            {
                WeaponSubType = (WeaponSubTypes)(RandomGenerator.random.Next(10, 12));
                return;
            }
        }
    }
}
