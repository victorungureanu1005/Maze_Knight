using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models.Comparers
{
    public class CoordinatesEqualityComparer : IEqualityComparer<List<int>>
    {
       

        public bool Equals(List<int> x, List<int> y)
        {

            if (x==null&&y==null)
            {
                return true;
            }
            else if (x==null||y==null)
            {
                return false;
            }
            else if (x[0] == y[0] && x[1] == y[1])
            {
                return true;
            }
            else return false;
        }

        public int GetHashCode(List<int> obj)
        {
            int hCode = obj[0] ^ obj[1];
            return hCode.GetHashCode();
        }
    }
}
