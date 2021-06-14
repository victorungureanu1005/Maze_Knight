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
    /// Interaction logic for CreditsView.xaml
    /// </summary>
    public partial class CreditsView : UserControl
    {
        public CreditsView()
        {
            InitializeComponent();
        }

        private void QuitApp(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void GoToMenu(object sender, RoutedEventArgs e)
        {
            Mediator.TheApp.SelectedViewModel = new MainMenuViewModel();
        }

    }
}
