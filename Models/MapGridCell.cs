using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models
{
    public class MapGridCell : BaseModel
    {
        private string _whatIsContained;
        public string WhatIsContained {
            get
            {
                return _whatIsContained;
            }
            set
            {
                _whatIsContained = value;
                OnPropertyChanged("WhatIsContained");
            }
        }

    }
}
