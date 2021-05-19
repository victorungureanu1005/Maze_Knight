using Maze_Knight.Models.Enums.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models.Items
{
    public class Bow : Weapon
    {
        public Bow() : base()
        {
            WeaponType = WeaponTypes.Bow;
        }

    }
}
