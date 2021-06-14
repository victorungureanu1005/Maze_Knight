using Maze_Knight.Converters;
using Maze_Knight.Models;
using Maze_Knight.Models.Enums.Items;
using Maze_Knight.Models.Items;
using Maze_Knight.StaticClasses;
using Maze_Knight.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Maze_Knight.Views
{
    /// <summary>
    /// Interaction logic for StatsAndInventoryView.xaml
    /// </summary>
    public partial class StatsAndInventoryView : UserControl
    {
        #region Constants
        private const double ITEM_BORDER_WIDTH = 1D;
        private const int ITEM_IMAGE_SQUARE_SIDE_LENGTH = 85;
        private StatsAndInventoryViewModel _currentStatsAndInventoryViewModel;

        public StatsAndInventoryViewModel CurrentStatsAndInventoryViewModel { get => _currentStatsAndInventoryViewModel; set => _currentStatsAndInventoryViewModel = value; }
        #endregion
        public StatsAndInventoryView()
        {
            InitializeComponent();
            CurrentStatsAndInventoryViewModel = new StatsAndInventoryViewModel();
            DataContext = CurrentStatsAndInventoryViewModel;
            InitializePlayerInventory();

        }

        #region Inventory Initializations
        private void InitializePlayerInventory()
        {
            //Add columns and rows to the grid
            for (int i = 0; i < 4; i++)
            {
                PlayerInventory.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ITEM_IMAGE_SQUARE_SIDE_LENGTH) });
            }
            for (int i = 0; i < 4; i++)
            {
                PlayerInventory.RowDefinitions.Add(new RowDefinition { Height = new GridLength(ITEM_IMAGE_SQUARE_SIDE_LENGTH) });
            }

            //Set itemIndex to go through the items in the Inventory Collection of the player in order to set the bindings
            int itemIndex = 0;
            //Add the actual Images
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //Check if inventory is null or empty and checks if index went beyond item collection count in order to prevent exceptions
                    if (PlayerInstances.CurrentPlayerInstance.PlayerInventory != null && itemIndex < PlayerInstances.CurrentPlayerInstance.PlayerInventory.InventoryCollection.Count)
                    {
                        //Create the binding needed for the image display and set its properties linking it to the items in the respective inventory
                        Binding binding = new Binding();
                        var currentItem = PlayerInstances.CurrentPlayerInstance.PlayerInventory.InventoryCollection[itemIndex];
                        var itemTypeObject = currentItem.ItemType;
                        itemIndex++;
                        binding.Source = itemTypeObject;
                        ItemTypeToBitmapConverter converter = new ItemTypeToBitmapConverter();
                        binding.Converter = converter;
                        Image image = new Image();
                        image.SetBinding(Image.SourceProperty, binding);

                        //Add Selector and respective Event Handler
                        image.MouseDown += new MouseButtonEventHandler(ItemInPlayerInventoryClicked);
                        //Add PopUp Event Handler
                        if (currentItem is Weapon)
                        {
                            image.MouseEnter += new MouseEventHandler((sender, e) => WeaponPopUp(sender, e, (Weapon)currentItem));
                        }
                        if (currentItem is Armour)
                        {
                            image.MouseEnter += new MouseEventHandler((sender, e) => ArmourPopUp(sender, e, (Armour)currentItem));
                        }
                        image.MouseLeave += Item_MouseLeave;

                        //Set the position of the image in the grid
                        Grid.SetColumn(image, i);
                        Grid.SetRow(image, j);
                        //Add image to Grid Children so that it actually appears
                        PlayerInventory.Children.Add(image);

                        //Create Border and set properties
                        var myBorder = new Border { BorderBrush = new SolidColorBrush(Color.FromRgb(10, 20, 40)), BorderThickness = new Thickness { Bottom = ITEM_BORDER_WIDTH, Top = ITEM_BORDER_WIDTH, Left = ITEM_BORDER_WIDTH, Right = ITEM_BORDER_WIDTH } };
                        myBorder.SetValue(Grid.ColumnProperty, i);
                        myBorder.SetValue(Grid.RowProperty, j);
                        //Add Border to the Children of the Grid so that it actually appears
                        PlayerInventory.Children.Add(myBorder);
                    }
                }
            }
        }

        private void ItemInPlayerInventoryClicked(object sender, MouseButtonEventArgs e)
        {
            //Gets the index of the selected item by dividing the index of the image with 2 as we also have borders as children of the grid
            int index = PlayerInventory.Children.IndexOf((Image)sender) / 2;
            //Sets the selected armour/weapon in the view model to the respective item
            var item = CurrentStatsAndInventoryViewModel.CurrentPlayer.PlayerInventory.InventoryCollection[index];
            switch (item.ItemType)
            {
                case ItemTypes.Armour: CurrentStatsAndInventoryViewModel.SelectedArmourFromInventory = (Armour)item; CurrentStatsAndInventoryViewModel.SelectedWeaponFromInventory = null; break;
                case ItemTypes.Sword: CurrentStatsAndInventoryViewModel.SelectedWeaponFromInventory = (Weapon)item; CurrentStatsAndInventoryViewModel.SelectedArmourFromInventory = null; break;
                case ItemTypes.Bow: CurrentStatsAndInventoryViewModel.SelectedWeaponFromInventory = (Weapon)item; CurrentStatsAndInventoryViewModel.SelectedArmourFromInventory = null; break;
                case ItemTypes.Halberd: CurrentStatsAndInventoryViewModel.SelectedWeaponFromInventory = (Weapon)item; CurrentStatsAndInventoryViewModel.SelectedArmourFromInventory = null; break;
                default: break;
            }
        }

        private void ReinitializePlayerInventory()
        {
            //Remove the columns and rows of the two grids
            PlayerInventory.ColumnDefinitions.Clear();
            PlayerInventory.RowDefinitions.Clear();
            //Remove the children of the two grids (images and borders)
            PlayerInventory.Children.Clear();
            //Reinitialize the two inventories
            InitializePlayerInventory();
        }
        #endregion

        #region Navigator Buttons
        //Go back to Town View
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Mediator.TheApp.SelectedViewModel = new TownViewModel();
        }
        #endregion

        #region Equip/Unequip Buttons
        //Equip Item
        private void Equip_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentStatsAndInventoryViewModel.SelectedWeaponFromInventory != null)
            {
                CurrentStatsAndInventoryViewModel.CurrentPlayer.EquipWeapon(CurrentStatsAndInventoryViewModel.SelectedWeaponFromInventory);
                CurrentStatsAndInventoryViewModel.SelectedWeaponFromInventory = null;
                ReinitializePlayerInventory();
            }
            if (CurrentStatsAndInventoryViewModel.SelectedArmourFromInventory != null)
            {
                CurrentStatsAndInventoryViewModel.CurrentPlayer.EquipArmour(CurrentStatsAndInventoryViewModel.SelectedArmourFromInventory);
                CurrentStatsAndInventoryViewModel.SelectedArmourFromInventory = null;
                ReinitializePlayerInventory();
            }
        }
        //UnEquip Item
        private void UnEquip_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentStatsAndInventoryViewModel.SelectedEquippedWeapon != null)
            {
                CurrentStatsAndInventoryViewModel.CurrentPlayer.UnequipWeapon(CurrentStatsAndInventoryViewModel.SelectedEquippedWeapon);
                CurrentStatsAndInventoryViewModel.SelectedEquippedWeapon = null;
                ReinitializePlayerInventory();
            }
            if (CurrentStatsAndInventoryViewModel.SelectedEquippedArmour != null)
            {
                CurrentStatsAndInventoryViewModel.CurrentPlayer.UnequipArmour(CurrentStatsAndInventoryViewModel.SelectedEquippedArmour);
                CurrentStatsAndInventoryViewModel.SelectedEquippedArmour = null;
                ReinitializePlayerInventory();
            }
        }
        #endregion

        #region PopUp Events
        private void EquippedWeapon_MouseEnter(object sender, MouseEventArgs e)
        {
            //Set weapon reference and call the pop-up method
            Weapon equippedWeapon = CurrentStatsAndInventoryViewModel.CurrentPlayer.EquippedWeapon;
            //Call the Weapon PopUp with the appropiate parameter
            WeaponPopUp(sender, e, equippedWeapon);
        }

        private void EquippedArmour_MouseEnter(object sender, MouseEventArgs e)
        {
            //Set reference
            Armour equippedArmour = CurrentStatsAndInventoryViewModel.CurrentPlayer.EquippedArmour;
            ArmourPopUp(sender, e, equippedArmour);
        }

        //Helper function for the Weapon Pop-Up
        private void WeaponPopUp(object sender, MouseEventArgs e, Weapon hoveredWeapon)
        {
            if (hoveredWeapon != null)
            {
                PopUp.IsOpen = true;
                PopUp.PlacementTarget = (Image)sender;
                PopUp.Placement = PlacementMode.Right;
                PopUpItemName.Text = $"{hoveredWeapon.ItemName}  ";
                PopUpItemStats.Text =
                    $"Min Damage Bonus: {hoveredWeapon.MinDamageBonus} \x0A" +
                    $"Max Damage Bonus: {hoveredWeapon.MaxDamageBonus} \x0A" +
                    $"Sword Skill Bonus: {hoveredWeapon.SwordSkillBonus} \x0A" +
                    $"Bow Skill Bonus: {hoveredWeapon.BowSkillBonus} \x0A" +
                    $"Halberd Skill Bonus: {hoveredWeapon.HalberdSkillBonus} \x0A" +
                    $"Sell Price: {hoveredWeapon.ItemSellPrice} ";
            }
        }

        //Helper function for the Armour Pop-Up
        private void ArmourPopUp(object sender, MouseEventArgs e, Armour hoveredArmour)
        {
            if (hoveredArmour != null)
            {
                PopUp.IsOpen = true;
                PopUp.PlacementTarget = (Image)sender;
                PopUp.Placement = PlacementMode.Right;
                //White spaces left intentionally
                PopUpItemName.Text = $"{ hoveredArmour.ItemName}  ";
                PopUpItemStats.Text =
                    $"Health Bonus: {hoveredArmour.HealthBonus} \x0A" +
                    $"Humanoid Resistance Bonus: {hoveredArmour.HumanoidResistanceBonus} \x0A" +
                    $"Mystical Resistance Bonus: {hoveredArmour.MysticalResistanceBonus} \x0A" +
                    $"Sell Price: {hoveredArmour.ItemSellPrice} ";
            }
        }
        //Pop-up content is reset on every mouse leave
        private void Item_MouseLeave(object sender, MouseEventArgs e)
        {
            PopUp.IsOpen = false;
            PopUpItemName.Text = "";
            PopUpItemStats.Text = "";
        }

        #endregion

        //Equipped Weapon is selected in the view model for unequip future action
        private void EquippedWeapon_Click(object sender, MouseEventArgs e)
        {
            CurrentStatsAndInventoryViewModel.SelectedEquippedWeapon = CurrentStatsAndInventoryViewModel.CurrentPlayer.EquippedWeapon;
            CurrentStatsAndInventoryViewModel.SelectedEquippedArmour = null;
        }

        //Equipped Armour is selected in the view model for unequip future action
        private void EquippedArmour_Click(object sender, MouseEventArgs e)
        {
            CurrentStatsAndInventoryViewModel.SelectedEquippedArmour = CurrentStatsAndInventoryViewModel.CurrentPlayer.EquippedArmour;
            CurrentStatsAndInventoryViewModel.SelectedEquippedWeapon = null;
        }
    }
}
