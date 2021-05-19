using Maze_Knight.Models.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models
{
    class ShadyDealerInventoryModel
    {
        /// <summary>
        /// NEED TO WORK ON THIS
        /// WORK WORK
        /// WORK WORK
        /// </summary>
        #region Backing Fields
        private ObservableCollection<Item> _currentOffer = new ObservableCollection<Item>();
        private int _currentPlayerLevel;

        #endregion

        #region Properties
        public ObservableCollection<Item> CurrentOffer { get => _currentOffer; set => _currentOffer=value; }

        #endregion

        #region Main Method
        public void GenerateOffer()
        {
            GenerateWeaponOffer();
            GenerateArmourOffer();
            GeneratePotionOffer();
            CurrentOffer.Add(new Rune());
        }
        #endregion

        #region Helper Functions
        private void GenerateWeaponOffer()
        {

        }
        private void GenerateArmourOffer()
        {

        }
        private void GeneratePotionOffer()
        {

        }

        #endregion

    }
}
