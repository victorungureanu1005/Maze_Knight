using Maze_Knight.StaticClasses;
using Maze_Knight.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for StatsAndInventoryView.xaml
    /// </summary>
    public partial class StatsAndInventoryView : UserControl
    {
        public StatsAndInventoryView()
        {
            InitializeComponent();
            DataContext = new StatsAndInventoryViewModel();

        }

        private void mouse_MouseEnter(object sender, MouseEventArgs e)
        {
            PopUp.IsOpen = true;
            PopUp.PlacementTarget = (Image)sender;
            PopUp.Placement = PlacementMode.Right;
            PopUpItemName.Text = ((StatsAndInventoryViewModel)DataContext).CurrentPlayer.EquippedArmour.ItemName;    
            PopUpItemStats.Text = $"Stats are: Health: {((StatsAndInventoryViewModel)DataContext).CurrentPlayer.EquippedArmour.HealthBonus}";
        }

        private void mouse_MouseLeave(object sender, MouseEventArgs e)
        {
            PopUp.IsOpen = false;
            PopUpItemName.Text = "";
            PopUpItemStats.Text = "";
        }
    }
}
