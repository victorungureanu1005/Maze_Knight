﻿using Maze_Knight.ViewModels;
using System;
using System.Windows.Input;


namespace Maze_Knight.Commands
{
    public class UpdateViewCommand : ICommand
    {
        public UpdateViewCommand(AppWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        private AppWindowViewModel viewModel;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "TownView")
            {
                viewModel.SelectedViewModel = new TownViewModel() ;
            }
            else if(parameter.ToString() == "LoadGame")
            {
                viewModel.SelectedViewModel = new LoadGameViewModel();
            }
            else if(parameter.ToString() == "MainMenu")
            {
                viewModel.SelectedViewModel = new MainMenuViewModel();
            }
        }
    }
}
