using Maze_Knight.Models;
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

namespace Maze_Knight.Views.UserControls
{
    /// <summary>
    /// Interaction logic for DeathUserControl.xaml
    /// </summary>
    public partial class DeathUserControl : UserControl
    {
        public DeathUserControl()
        {
            InitializeComponent();
        }

        private void TryAgain(object sender, RoutedEventArgs e)
        {
            Mediator.theApp.SelectedViewModel = new TownViewModel();
            PlayerInstances.CurrentPlayerInstance.TryAgainAfterDeath();
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            Mediator.theApp.SelectedViewModel = new MainMenuViewModel();
        }
    }
}
