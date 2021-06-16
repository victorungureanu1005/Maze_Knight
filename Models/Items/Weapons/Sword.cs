using Maze_Knight.Models.Enums.Items;
using Maze_Knight.Models.Enums.Items.Weapons;
using Maze_Knight.StaticClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models.Items
{
    public class Sword : Weapon
    {
        public Sword() : base()
        {
            //Setting item types necessary for image binding on inventories and shady dealer
            ItemType = ItemTypes.Sword;
            SetSwordSubType();
            //Set name of weapon after subtype has been given
            SetWeaponName();
        }
        private void SetSwordSubType()
        {
            //Set random Weapon SubType from specific range depending on level. 
            if (PlayerLevelWhenGenerated <= 6)
            {
                WeaponSubType = (WeaponSubTypes)(RandomGenerator.random.Next(0, 2));
                return;
            }
            if (PlayerLevelWhenGenerated <= 12)
            {
                WeaponSubType = (WeaponSubTypes)(RandomGenerator.random.Next(2, 4));
                return;
            }
            if (PlayerLevelWhenGenerated > 12)
            {
                WeaponSubType = (WeaponSubTypes)(RandomGenerator.random.Next(4, 6));
                return;
            }
        }
    }
}
