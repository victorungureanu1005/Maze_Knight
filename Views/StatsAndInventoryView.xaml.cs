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
            DataContext = new StatsAndInventoryViewModel();

            InitializePlayerInventory();

        }

        #region
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
                        image.MouseEnter += new MouseEventHandler((sender, e) => PopUpInitializationOnPlayerInventory(sender, e, currentItem));
                        image.MouseLeave += new MouseEventHandler((sender, e) => PopUpDeInitialization(sender, e, currentItem));

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
                case ItemTypes.Armour: CurrentStatsAndInventoryViewModel.SelectedArmour = (Armour)item; CurrentStatsAndInventoryViewModel.SelectedWeapon = null; break;
                case ItemTypes.Sword: CurrentStatsAndInventoryViewModel.SelectedWeapon = (Weapon)item; CurrentStatsAndInventoryViewModel.SelectedArmour = null; break;
                case ItemTypes.Bow: CurrentStatsAndInventoryViewModel.SelectedWeapon = (Weapon)item; CurrentStatsAndInventoryViewModel.SelectedArmour = null; break;
                case ItemTypes.Halberd: CurrentStatsAndInventoryViewModel.SelectedWeapon = (Weapon)item; CurrentStatsAndInventoryViewModel.SelectedArmour = null; break;
                default: break;
            }
        }
        #endregion

        #region Navigator Buttons
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Mediator.theApp.SelectedViewModel = new TownViewModel();
        }
        #endregion

        #region PopUp Events
        private void EquippedWeapon_MouseEnter(object sender, MouseEventArgs e)
        {
            //Set reference
            Weapon equippedWeapon = CurrentStatsAndInventoryViewModel.CurrentPlayer.EquippedWeapon;

            if (equippedWeapon != null)
            {
                PopUp.IsOpen = true;
                PopUp.PlacementTarget = (Image)sender;
                PopUp.Placement = PlacementMode.Right;
                PopUpItemName.Text = $"{equippedWeapon.ItemName}  ";
                PopUpItemStats.Text =
                    $"Min Damage Bonus: {equippedWeapon.MinDamageBonus} \x0A" +
                    $"Max Damage Bonus: {equippedWeapon.MaxDamageBonus} \x0A" +
                    $"Sword Skill Bonus: {equippedWeapon.SwordSkillBonus} \x0A" +
                    $"Bow Skill Bonus: {equippedWeapon.BowSkillBonus} \x0A" +
                    $"Halberd Skill Bonus: {equippedWeapon.HalberdSkillBonus} \x0A" +
                    $"Sell Price: {equippedWeapon.ItemSellPrice} ";
            }
        }

        private void EquippedArmour_MouseEnter(object sender, MouseEventArgs e)
        {            
            //Set reference
            Armour equippedArmour = CurrentStatsAndInventoryViewModel.CurrentPlayer.EquippedArmour;

            if (equippedArmour != null)
            {
                PopUp.IsOpen = true;
                PopUp.PlacementTarget = (Image)sender;
                PopUp.Placement = PlacementMode.Right;
                PopUpItemName.Text = $"{ equippedArmour.ItemName}  ";
                PopUpItemStats.Text =
                    $"Health Bonus: {equippedArmour.HealthBonus} \x0A" +
                    $"Humanoid Resistance Bonus: {equippedArmour.HumanoidResistanceBonus} \x0A" +
                    $"Mystical Resistance Bonus: {equippedArmour.MysticalResistanceBonus} \x0A" +
                    $"Sell Price: {equippedArmour.ItemSellPrice} ";
            }
        }
        private void Item_MouseLeave(object sender, MouseEventArgs e)
        {
            PopUp.IsOpen = false;
            PopUpItemName.Text = "";
            PopUpItemStats.Text = "";
        }

        #endregion

    }
}
