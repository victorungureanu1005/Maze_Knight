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
    /// Interaction logic for NewGameUserControl.xaml
    /// </summary>
    public partial class NewGameUserControl : UserControl
    {
        public NewGameUserControl()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NameGameUserControl.Visibility = Visibility.Hidden;
            //Finds the root parent of this user control in the MainMenu View
            FrameworkElement parentFrameWorkElementToBe = (FrameworkElement)NameGameUserControl.Parent;
            while (parentFrameWorkElementToBe.Parent is FrameworkElement)
            {
                parentFrameWorkElementToBe = (FrameworkElement)parentFrameWorkElementToBe.Parent;
            }
            //Sets the mainMenuGrid to the Grid named "MainMenu" in the MainMenuView
            var mainMenuGrid = parentFrameWorkElementToBe.FindName("MainMenu");

            //Sets the Opacity level and enabled setting accordingly 
            if (mainMenuGrid is Grid)
            {
                ((Grid)mainMenuGrid).Opacity = 1.00;
                ((Grid)mainMenuGrid).IsEnabled = true;
            }

        }
    }
}
