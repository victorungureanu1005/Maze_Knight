using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models.Enums.Items.Weapons
{
    //If other weapons are added, the random limits in the constructor must be modified. 
    public enum WeaponSubTypes
    {
        #region Swords
        //Weapons under 6
        IronSword,
        SteelSword,
        //Weapons under 12
        BlackIronSword,
        FlamingSword,
        //Weapons under 18
        DiamondSword,
        FlamingDiamondSword,

        #endregion

        #region Bows
        //Weapons under 6
        IronBow,
        SteelBow,
        //Weapons under 12
        BlackIronBow,
        FlamingBow,
        //Weapons under 18
        DiamondBow,
        FlamingDiamondBow,

        #endregion

        #region Halberds
        //Weapons under 6
        IronHalberd,
        SteelHalberd,
        //Weapons under 12
        BlackIronHalberd,
        FlamingHalberd,
        //Weapons under 18
        DiamondHalberd,
        FlamingDiamondHalberd,

        #endregion
    }

}
