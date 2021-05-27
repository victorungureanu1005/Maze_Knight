using Maze_Knight.Models.Enums.Items;
using Maze_Knight.Models.Enums.Items.Weapons;
using Maze_Knight.StaticClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models.Items
{
    public class Halberd : Weapon
    {
        public Halberd() : base()
        {
            //Setting item types necessary for image binding on inventories and shady dealer
            ItemType = ItemTypes.Halberd;
            SetHalberdSubType();
            //Set name of weapon after subtype has been given
            SetWeaponName();
        }
        private void SetHalberdSubType()
        {
            //Set random Weapon SubType from specific range depending on level. 
            if (PlayerLevelWhenGenerated <= 6)
            {
                WeaponSubType = (WeaponSubTypes)(RandomGenerator.random.Next(12, 14));
                return;
            }
            if (PlayerLevelWhenGenerated <= 12)
            {
                WeaponSubType = (WeaponSubTypes)(RandomGenerator.random.Next(14, 16));
                return;
            }
            if (PlayerLevelWhenGenerated > 12)
            {
                WeaponSubType = (WeaponSubTypes)(RandomGenerator.random.Next(16, 18));
                return;
            }
        }
    }
}
