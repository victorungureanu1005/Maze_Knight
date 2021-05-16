using Maze_Knight.Commands;
using Maze_Knight.Models.Enums;
using Maze_Knight.StaticClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Maze_Knight.Models
{
    public class MapGridCell : BaseModel
    {
        #region Backing Fields

        private string _cellTextDisplay = "?";
        private int _cellColumnNumber;
        private int _cellRowNumber;
        private bool _reveal = false;
        private bool _wasExplored = false;
        private bool _playerIsHere;
        private bool _exitIsHere;
        private bool _enemyIsHere;
        private Enemy _enemy;

        #endregion

        #region Properties
        //Text to display on the Grid Cells of the Explore View - Bounds are set in the View
        public string CellTextDisplay
        {
            get
            {
                if (PlayerIsHere) return "♟";
                if (EnemyIsHere==true)
                {
                    switch (Enemy.EnemySubType)
                    {
                        case EnemySubTypes.Rogues: return "🔪";
                        case EnemySubTypes.ThievyArchers: return "🏹";
                        case EnemySubTypes.CorruptPaladins: return "🧛‍♂️";
                        case EnemySubTypes.CorruptMages: return "🦹‍♂️";

                        case EnemySubTypes.Goblins: return "🤢";
                        case EnemySubTypes.Orcs: return "👽";
                        case EnemySubTypes.Trolls: return "😈";
                        case EnemySubTypes.Dragons: return "🐉";
                    }
                }
                if (ExitIsHere) return "🕳";
                //if (WasExplored) return "✔";
                return _cellTextDisplay;
            }
        }
        //Cell Column Number
        public int CellColumnNumber
        {
            get { return _cellColumnNumber; }
            set { _cellColumnNumber = value; }
        }
        //Cell Row Number
        public int CellRowNumber
        {
            get { return _cellRowNumber; }
            set { _cellRowNumber = value; }
        }
        //Property set to false from the beginning - might be usefull if player uses a torch - if reveal set to true -> reeal enemy -> change CellTextDisplay
        public bool Reveal
        {
            get { return _reveal; }
            set { _reveal = value; }
        }
        //Indicator if Cell was already explored by player
        public bool WasExplored
        {
            get { return _wasExplored; }
            set
            {
                _wasExplored = value;
                OnPropertyChanged(nameof(CellTextDisplay));
            }
        }
        //Gets player's current location
        public bool PlayerIsHere
        {
            get
            {
                return _playerIsHere;
            }
            set
            {
                _playerIsHere = value;
                OnPropertyChanged(nameof(CellTextDisplay));
            }
        }
        //Specifies if Exit is on this cell
        public bool ExitIsHere
        {
            get { return _exitIsHere; }
            set { _exitIsHere = value; }
        }
        //Specifies if enemy is on this cell
        public bool EnemyIsHere
        {
            get { return _enemyIsHere; }
            set { _enemyIsHere = value;
                OnPropertyChanged(nameof(CellTextDisplay));
            }
        }
        //Specifies type of enemy is on this cell
        public Enemy Enemy
        {
            get { return _enemy; }
            set { _enemy = value; }
        }

        #endregion

        #region Commands bound in the ExploreView
        public ICommand MapGridCellClickCommand { get; set; }

        public MapGridCell()
        {
            MapGridCellClickCommand = new MapGridCellClickCommand(this);
        }
        #endregion
    }
}
