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
    /// <summary>
    /// Interaction logic for ExploreView.xaml
    /// </summary>
    public partial class ExploreView : UserControl
    {
        #region Private Fields and Constants
        const int MIN_WIDTH = 6;
        const int MIN_HEIGHT = 6;
        const float GRID_EXPANSE_RATE = 0.3f;



        #endregion

        #region Constructor
        public ExploreView()
        {
            InitializeComponent();
            InitializeMapGrid((float)PlayerInstances.CurrentPlayerInstance.Level);


            DataContext = Mediator.theApp.SelectedViewModel;

            int i = 0;
            foreach (var child in MapGrid.Children.OfType<TextBlock>())
            {
                //ObservableCollection<TextBoxContentTest> test = testExploreViewModel.TextBoxContentTestsCollection;
                //child.Text = test[0].Name;
                //SetBinding(TextBlock.TextProperty, test[0].Name).ToString(); 
             

                if (i < 20)
                {

                    Binding childBinding = new Binding();
                    var testObject2 = ((ExploreViewModel)Mediator.theApp.SelectedViewModel).TextBoxContentTestsCollection[i];
                    childBinding.Source = testObject2;
                    childBinding.Path = new PropertyPath("Age");
                    childBinding.BindsDirectlyToSource = true;

                    child.SetBinding(TextBlock.TextProperty, childBinding);
                    i++;
                    
                }



            }







        }
        #endregion



        #region MapGrid Construction

        /// <summary>
        /// Initializing Grid based on player level
        /// </summary>
        /// <param name="_playerLevel"></param>
        public void InitializeMapGrid(float _playerLevel)
        {
            //set actual width and height of the map grid
            int actualWidth = (int)Math.Round(MIN_WIDTH + (_playerLevel * GRID_EXPANSE_RATE));
            int actualHeight = (int)Math.Round(MIN_HEIGHT + (_playerLevel * GRID_EXPANSE_RATE));

            // add columns and rows
            for (int i = 0; i < actualWidth; i++)
            {
                MapGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50) });
            }
            for (int i = 0; i < actualHeight; i++)
            {
                MapGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            }

            //add the actual Text Blocks = Maze
            for (int i = 0; i < actualWidth; i++)
            {
                for (int j = 0; j < actualHeight; j++)
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

        private void Text_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Grid.GetColumn((TextBlock)sender);
        }
    }
}
