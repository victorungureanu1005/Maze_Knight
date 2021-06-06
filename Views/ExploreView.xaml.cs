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
        #region Private Fields
        //Additional Collection needed for reference purposes
        private ObservableCollection<TextBlock> _textBlockCollection = new ObservableCollection<TextBlock>();
        #endregion

        #region ExploreViewConstructor
        public ExploreView()
        {
            //Standard initialization
            InitializeComponent();

            //Instantiation of MapMeasures class to use map measure methods
            MapMeasures mapMeasures = new MapMeasures(PlayerInstances.CurrentPlayerInstance);
            //Actual creating of the map grid is called
            InitializeMapGrid((int)PlayerInstances.CurrentPlayerInstance.Level, mapMeasures);

            //Setting the DataContext for this View - shall be set to the ExploreViewModel created by the static App class instantiated and stored in the Mediator static class
            //Also setting Binders between TextBoxes and relevant MapGridCell objects
            DataContext = (ExploreViewModel)Mediator.theApp.SelectedViewModel;
            SetBindersToCells((int)PlayerInstances.CurrentPlayerInstance.Level, mapMeasures);

        }
        #endregion

        #region ExploreView Methods for Map Creation

        /// <summary>
        /// Create Columns and Rows in the specified Grid, set up Text Blocks and Borders on the Grid. Also fills in the private collection stored on this class exactly the same as the one in the ExploreViewModel is stored 
        /// </summary>
        /// <param name="_playerLevel">Player reference needed</param>
        /// <param name="mapMeasures">MapMeasures instantiation needed (is instantiated in the constructor)</param>
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
                    //Set font size and font weight of text in the map grid cell/ text block
                    TextBlock textBlock = new TextBlock() { FontSize = 20, FontWeight = FontWeights.Bold };
                    Grid.SetColumn(textBlock, i);
                    Grid.SetRow(textBlock, j);

                    textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                    textBlock.VerticalAlignment = VerticalAlignment.Center;


                    MapGrid.Children.Add(textBlock);
                    _textBlockCollection.Add(textBlock);

                    var myBorder = new Border { BorderBrush = new SolidColorBrush(Color.FromRgb(10, 20, 40)), BorderThickness = new Thickness { Bottom = 0.1, Top = 0.1, Left = 0.1, Right = 0.1 } };
                    MapGrid.Children.Add(myBorder);
                    myBorder.SetValue(Grid.ColumnProperty, i);
                    myBorder.SetValue(Grid.RowProperty, j);
                }
            }
        }
        /// <summary>
        /// Setting up bindings between the TextBlocks created and the Text to be displayed found in the collection stored and modified in the ExploreViewModel. Also sets up the MouseDown event for each TextBlock created.
        /// </summary>
        /// <param name="_playerLevel">Player reference needed</param>
        /// <param name="mapMeasures">MapMeasures instantiation needed (is instantiated in the constructor)</param>
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

                    //Set the MouseDown event on the TextBlock to also call the Event Handler (GridCellClick Method)
                    child.MouseDown += new System.Windows.Input.MouseButtonEventHandler(GridCellClick);
                    i++;
                }
            }
        }
        #endregion

        #region MapGrid Functions
        /// <summary>
        /// Executes command stored on MapGridCell
        /// </summary>
        private void GridCellClick(object sender, MouseButtonEventArgs e)
        {
            int index = _textBlockCollection.IndexOf((TextBlock)sender);
            ((ExploreViewModel)Mediator.theApp.SelectedViewModel).MapGridCellCollection[index].MapGridCellClickCommand.Execute(sender);
        }
        #endregion

        #region Action Buttons
        //Go back to Town
        private void Flight(object sender, RoutedEventArgs e)
        {
            Mediator.theApp.SelectedViewModel = new TownViewModel();
        }

        //Change player's current weapon to sword
        private void SelectSword(object sender, RoutedEventArgs e)
        {
            PlayerInstances.CurrentPlayerInstance.PlayerSelectedWeapon = Models.Enums.PlayerSelectedWeapon.Sword;
            SelectedWeapon.Text = $"You will fight with your {PlayerInstances.CurrentPlayerInstance.PlayerSelectedWeapon}";
        }
        //Change player's current weapon to bow
        private void SelectBow(object sender, RoutedEventArgs e)
        {
            PlayerInstances.CurrentPlayerInstance.PlayerSelectedWeapon = Models.Enums.PlayerSelectedWeapon.Bow;
            SelectedWeapon.Text = $"You will fight with your {PlayerInstances.CurrentPlayerInstance.PlayerSelectedWeapon}";
        }
        //Change player's current weapon to halberd
        private void SelectHalberd(object sender, RoutedEventArgs e)
        {
            PlayerInstances.CurrentPlayerInstance.PlayerSelectedWeapon = Models.Enums.PlayerSelectedWeapon.Halberd;
            SelectedWeapon.Text = $"You will fight with your {PlayerInstances.CurrentPlayerInstance.PlayerSelectedWeapon}";
        }
        #endregion

        private void FightButton_Click(object sender, RoutedEventArgs e)
        {
            //Check if player is currently locked meaning he must do battle to get unlocked
            if (PlayerInstances.CurrentPlayerInstance.PlayerIsLocked == true)
            {
                BattleSystem battle = new BattleSystem();
                battle.Battle();
            }
            else return;
        }

        private void UseRuneButton(object sender, RoutedEventArgs e)
        {

        }
    }
}
