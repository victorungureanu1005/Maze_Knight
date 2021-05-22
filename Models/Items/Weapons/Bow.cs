using Maze_Knight.Models.Enums.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze_Knight.Models.Enums.Items.Weapons;

namespace Maze_Knight.Models.Items
{
    public class Bow : Weapon
    {
        Random random = new Random();
        public Bow(Player player) : base(player)
        {
            WeaponType = WeaponTypes.Bow;
            if (player.Level <= 6) WeaponSubType = (WeaponSubTypes)(random.Next(6, 8));
            if (player.Level <= 12) WeaponSubType = (WeaponSubTypes)(random.Next(8, 10));
            if (player.Level > 12) WeaponSubType = (WeaponSubTypes)(random.Next(10, 12));
            NameOfWeapon = WeaponSubType.ToString() + " of " + SwordNameSuffix;
        }

    }
}
