using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models.Enums
{
    /// <summary>
    /// This has been used like this to avoid manual adjustment of values in the Enemy classes. Values need to be unique though, 
    /// or specific values to be manually specified in the constructors of the Enemy classes. 
    /// </summary>
    enum EnemyResistancesSword
    {

    }

    enum EnemyResistancesArrow
    {

    }

    enum EnemyResistancesHalberd
    {
        HumanoidEnemies = 100,
        MysticalCreatues = 75
    }

    enum EnemyResistancesRune
    {

    }
}
