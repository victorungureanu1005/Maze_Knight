using Maze_Knight.Converters;
using Maze_Knight.StaticClasses;
using Maze_Knight.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    /// Interaction logic for ShadyDealerView.xaml
    /// </summary>
    public partial class ShadyDealerView : UserControl
    {
        private const double ITEM_BORDER_WIDTH = 1D;
        private const int ITEM_IMAGE_SQUARE_SIDE_LENGTH = 85;
        public ShadyDealerView()
        {
            InitializeComponent();
            //Setting data context to the shady dealer view model directly and not by creating a new view model
            DataContext = (ShadyDealerViewModel)Mediator.theApp.SelectedViewModel;

            InitializeShadyDealerInventoryGrid();

            InitializePlayerInventory();
        }

        private void ReturnToMenu_Click(object sender, RoutedEventArgs e)
        {
            Mediator.theApp.SelectedViewModel = new TownViewModel();
        }

        private void InitializeShadyDealerInventoryGrid()
        {
            //Add columns and rows to the grid
            for (int i = 0; i < 4; i++)
            {
                ShadyDealerInventory.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ITEM_IMAGE_SQUARE_SIDE_LENGTH) });
            }
            for (int i = 0; i < 2; i++)
            {
                ShadyDealerInventory.RowDefinitions.Add(new RowDefinition { Height = new GridLength(ITEM_IMAGE_SQUARE_SIDE_LENGTH) });
            }

            //Set itemIndex to go through the items in the Inventory Collection of the shady dealer and set bindings
            int itemIndex = 0;
            //Add the actual Images
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    //Create the binding needed for the image display and set its properties linking it to the items in the respective inventory
                    Binding binding = new Binding();
                    var itemTypeObject = ((ShadyDealerViewModel)Mediator.theApp.SelectedViewModel).ShadyDealer.ShadyDealerInventory.InventoryCollection[itemIndex].ItemType;
                    itemIndex++;
                    binding.Source = itemTypeObject;
                    ItemTypeToBitmapConverter converter = new ItemTypeToBitmapConverter();
                    binding.Converter = converter;
                    Image image = new Image();
                    image.SetBinding(Image.SourceProperty, binding);

                    //Set column and row of the image created above
                    Grid.SetColumn(image, i);
                    Grid.SetRow(image, j);
                    //Add image to Grid Children so that it actually appears
                    ShadyDealerInventory.Children.Add(image);

                    //Create Border and set properties
                    var myBorder = new Border { BorderBrush = new SolidColorBrush(Color.FromRgb(10, 20, 40)), BorderThickness = new Thickness { Bottom = ITEM_BORDER_WIDTH, Top = ITEM_BORDER_WIDTH, Left = ITEM_BORDER_WIDTH, Right = ITEM_BORDER_WIDTH } };
                    myBorder.SetValue(Grid.ColumnProperty, i);
                    myBorder.SetValue(Grid.RowProperty, j);
                    //Add Border to the Children of the Grid so that it actually appears
                    ShadyDealerInventory.Children.Add(myBorder);

                }
            }
        }

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
                    //Create the binding needed for the image display and set its properties linking it to the items in the respective inventory
                    Binding binding = new Binding();

                    //Check if inventory is null or empty and checks if index went beyond item collection count
                    if (PlayerInstances.CurrentPlayerInstance.PlayerInventory != null && itemIndex< PlayerInstances.CurrentPlayerInstance.PlayerInventory.InventoryCollection.Count)
                    {
                        var itemTypeObject = PlayerInstances.CurrentPlayerInstance.PlayerInventory.InventoryCollection[itemIndex].ItemType;
                        itemIndex++;
                        binding.Source = itemTypeObject;
                        ItemTypeToBitmapConverter converter = new ItemTypeToBitmapConverter();
                        binding.Converter = converter;
                        Image image = new Image();
                        image.SetBinding(Image.SourceProperty, binding);


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
    }
}
