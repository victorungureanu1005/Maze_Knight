using Maze_Knight.Commands;
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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenuView : UserControl
    {
        public MainMenuView()
        {
            InitializeComponent();
            DataContext = Mediator.TheApp;
            NewGameUserControl.DataContext = DataContext;

        }

        private void QuitApp(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            NewGameUserControl.Visibility = Visibility.Visible;
            MainMenu.Opacity = 0.4;
            MainMenu.IsEnabled = false;
        }
    }
}
