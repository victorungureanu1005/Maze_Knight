using Maze_Knight.Models.Enums.Items;
using Maze_Knight.Models.Enums.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models.Items
{
    public class Sword : Weapon
    {
        Random random = new Random();
        public Sword(Player player) : base(player)
        {
            WeaponType = WeaponTypes.Sword;
            if (player.Level <= 6) WeaponSubType = (WeaponSubTypes)(random.Next(0, 2));
            if (player.Level <= 12) WeaponSubType = (WeaponSubTypes)(random.Next(2, 4));
            if (player.Level > 12) WeaponSubType = (WeaponSubTypes)(random.Next(4, 6));
            NameOfWeapon = WeaponSubType.ToString() + " of " + SwordNameSuffix;
        }
    }
}
