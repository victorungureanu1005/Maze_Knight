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
    /// Interaction logic for ExitExploreUserControl.xaml
    /// </summary>
    public partial class ExitExploreUserControl : UserControl
    {
        public ExitExploreUserControl()
        {
            InitializeComponent();
        }

        private void GoToTown(object sender, RoutedEventArgs e)
        {
            Mediator.theApp.SelectedViewModel = new TownViewModel();
        }
    }
}
