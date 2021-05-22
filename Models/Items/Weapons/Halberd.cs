using Maze_Knight.Models.Enums.Items;
using Maze_Knight.Models.Enums.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models.Items
{
    public class Halberd : Weapon
    {

        Random random = new Random();
        public Halberd(Player player) : base(player)
        {
            WeaponType = WeaponTypes.Halberd;
            if (player.Level <= 6) WeaponSubType = (WeaponSubTypes)(random.Next(12, 14));
            if (player.Level <= 12) WeaponSubType = (WeaponSubTypes)(random.Next(14, 16));
            if (player.Level > 12) WeaponSubType = (WeaponSubTypes)(random.Next(16, 18));
            NameOfWeapon = WeaponSubType.ToString() + " of " + SwordNameSuffix;
        }
    }
}
