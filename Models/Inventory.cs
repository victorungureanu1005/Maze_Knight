using Maze_Knight.Models.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models
{
    public class Inventory : BaseModel
    {

        #region Backing Fields
        //Generic inventory information
        private int _inventoryCapacity = 20;
        private ObservableCollection<Item> _inventoryCollection = new ObservableCollection<Item>();

        //Equiped items
        private Weapon _equipedWeapon;
        private Armour _equipedArmour;
        private Accesory _equipedAccesory;

        #endregion

        #region Constructor
        Inventory()
        {
            
        }
        #endregion

        #region Generic Inventory Properties

        public int InventoryCapacity { get => _inventoryCapacity; set => _inventoryCapacity=value; }
        public ObservableCollection<Item> InventoryCollection { get => _inventoryCollection; set => _inventoryCollection=value; }

        #endregion

        #region Equiped items property
        public Weapon EquipedWeapon { get => _equipedWeapon; set => _equipedWeapon=value; }
        public Armour EquipedArmour { get => _equipedArmour; set => _equipedArmour=value; }
        public Accesory EquipedAccesory { get => _equipedAccesory; set => _equipedAccesory=value; }

        #endregion

        #region Inventory Methods

        #endregion
    }
}
