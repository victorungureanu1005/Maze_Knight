using Maze_Knight.Models.Enums;
using Maze_Knight.StaticClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models
{
    public class MapGridCell : BaseModel
    {

        #region Backing Fields

        private string _cellTextDisplay;
        private int _cellColumnNumber;
        private int _cellRowNumber;
        private bool _reveal;
        private bool _wasExplored;
        private bool _canMoveTo;
        private bool _exitIsHere;
        private bool _enemyIsHere;
        private EnemyTypes _enemyType;
        

        #endregion


        #region Properties
        public string CellTextDisplay
        {
            get { return _cellTextDisplay; }
            set
            {
                _cellTextDisplay = value;
                OnPropertyChanged(nameof(CellTextDisplay));
            }
        }
        public int CellColumnNumber
        {
            get { return _cellColumnNumber; }
            set { _cellColumnNumber = value; }
        }

        public int CellRowNumber
        {
            get { return _cellRowNumber; }
            set { _cellRowNumber = value; }
        }

        public bool Reveal
        {
            get { return _reveal; }
            set { _reveal = value; }
        }
              

        public bool WasExplored
        {
            get { return _wasExplored; }
            set { _wasExplored = value; }
        }

        //Gets Hero's current location - // needs to be optimized! Can't have this run over and over again on all cells - should be called!
        public bool HeroIsHere
        {
            get
            {
                if (PlayerInstances.CurrentPlayerInstance.PlayerLocation[0] == CellColumnNumber && PlayerInstances.CurrentPlayerInstance.PlayerLocation[1] == CellRowNumber)
                    return true;
                else return false;
            }
        }

        public bool ExitIsHere
        {
            get { return _exitIsHere; }
            set { _exitIsHere = value; }
        }


        public bool EnemyIsHere
        {
            get { return _enemyIsHere; }
            set { _enemyIsHere = value; }
        }

        public EnemyTypes EnemyType
        {
            get { return _enemyType; }
            set { _enemyType = value; }
        }


        #endregion


        // HERE! - create cross and check
        public bool CanMoveTo
        {
            get { return _canMoveTo; }
            set { _canMoveTo = value; }
        }


    }
}
