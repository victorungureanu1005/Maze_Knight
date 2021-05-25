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

            //Add the actual Images
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    //Create Image with specific properties and set it in the right column and grid
                    BitmapImage imageBitmap = new BitmapImage(new Uri("/Content/Icons/BowIcon_WBackground.png", UriKind.Relative));
                    Image image = new Image() { Source = imageBitmap };
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

            //Add the actual Images
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //Create Image with specific properties and set it in the right column and grid



                    ////BINDING HERE actually! IValueConverter - Same Above

                    ///string bitmapUriString = IValueConverter!!!!!!

                    BitmapImage imageBitmap = new BitmapImage(new Uri("/Content/Icons/BowIcon_WBackground.png", UriKind.Relative));
                    Image image = new Image() { Source = imageBitmap };
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
