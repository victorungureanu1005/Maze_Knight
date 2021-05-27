﻿using Maze_Knight.ViewModels;
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
    /// Interaction logic for TownView.xaml
    /// </summary>
    public partial class TownView : UserControl
    {
        public TownView()
        {
            InitializeComponent();
            DataContext = (TownViewModel)Mediator.theApp.SelectedViewModel;
        }

        private void GoToMainMenu(object sender, RoutedEventArgs e)
        {
            Mediator.theApp.SelectedViewModel = new MainMenuViewModel();

        }

        private void SaveGame(object sender, RoutedEventArgs e)
        {

        }

        private void LoadGame(object sender, RoutedEventArgs e)
        {

        }

        private void ExploreOutsideTown(object sender, RoutedEventArgs e)
        {
            Mediator.theApp.SelectedViewModel = new ExploreViewModel();
        }

        private void GoToShadyDealer(object sender, RoutedEventArgs e)
        {
            var currentTownViewModel = (TownViewModel)Mediator.theApp.SelectedViewModel;
            Mediator.theApp.SelectedViewModel = currentTownViewModel.ShadyDealerViewModel;
        }
    }
}
