using Maze_Knight.Models;
using Maze_Knight.StaticClasses;
using Maze_Knight.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ExploreView : UserControl
    {
        #region ExploreViewConstructor
        public ExploreView()
        {

            //Intrebare
            // Ar trebui sa obtin deja masurile la initializare sau sa folosesc call de fiecare data? Stocare vs. Procesare?
            //Intrebare

            //Standard initialization
            InitializeComponent();

            MapMeasures mapMeasures = new MapMeasures();
            //Map Grid actual creation called
            InitializeMapGrid((int)PlayerInstances.CurrentPlayerInstance.Level, mapMeasures);

            //Setting the DataContext for this View - shall be set to the ExploreViewModel created by the static App class instantiated and stored in the Mediator static class
            //Also setting Binders between TextBoxes and relevant MapGridCell objects
            DataContext = Mediator.theApp.SelectedViewModel;
            SetBindersToCells((int)PlayerInstances.CurrentPlayerInstance.Level, mapMeasures);

        }
        #endregion

        #region ExploreViewMethods

        private void SetBindersToCells(int currentPlayerLevel, MapMeasures mapMeasures)
        {
            //Get reference to property name
            string _cellTextDisplay = nameof(MapGridCell.CellTextDisplay);

            //Bind each cell(TextBlock) of the MapGrid to the MapGridCell Object in the ObservableCollection of the ExploreViewModel
            //Indexer is needed as to not go less than or over the Collection Length
            int i = 0;
            foreach (var child in MapGrid.Children.OfType<TextBlock>())
            {
                if (i < mapMeasures.GetMaxCellNumber())
                {
                    //Create new binding to be able to set binding
                    Binding binding = new Binding();

                    //Find the mapGridCellObject to which the binding must be linked
                    var mapGridCellObject = ((ExploreViewModel)Mediator.theApp.SelectedViewModel).MapGridCellCollection[i];

                    //Bind the source to the object and set the path to the relevant property
                    binding.Source = mapGridCellObject;
                    binding.Path = new PropertyPath(_cellTextDisplay);

                    //Set the binding and increase the indexer
                    child.SetBinding(TextBlock.TextProperty, binding);
                    i++;
                }
            }
        }

        public void InitializeMapGrid(int _playerLevel, MapMeasures mapMeasures)
        {
            //Add columns and rows to the grid
            for (int i = 0; i < mapMeasures.GetMaxColumn(); i++)
            {
                MapGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50) });
            }
            for (int i = 0; i < mapMeasures.GetMaxRow(); i++)
            {
                MapGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            }

            //Add the actual Text Blocks and Borders
            for (int i = 0; i < mapMeasures.GetMaxColumn(); i++)
            {
                for (int j = 0; j < mapMeasures.GetMaxRow(); j++)
                {
                    TextBlock textBlock = new TextBlock();
                    Grid.SetColumn(textBlock, i);
                    Grid.SetRow(textBlock, j);

                    textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                    textBlock.VerticalAlignment = VerticalAlignment.Center;

                    MapGrid.Children.Add(textBlock);

                    var myBorder = new Border { BorderBrush = new SolidColorBrush(Color.FromRgb(10, 20, 40)), BorderThickness = new Thickness { Bottom = 0.5, Top = 0.5, Left = 0.5, Right = 0.5 } };
                    MapGrid.Children.Add(myBorder);
                    myBorder.SetValue(Grid.ColumnProperty, i);
                    myBorder.SetValue(Grid.RowProperty, j);
                }
            }
        }

        #endregion

        #region MapGrid Functions

        #endregion

        #region Action Buttons
        private void Flight(object sender, RoutedEventArgs e)
        {
            Mediator.theApp.SelectedViewModel = new MainMenuViewModel();
        }

        #endregion
    }
}
