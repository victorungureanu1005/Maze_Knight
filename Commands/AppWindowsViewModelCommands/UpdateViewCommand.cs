using Maze_Knight.ViewModels;
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
            //Intrebare
            //Try-catch-la catch intru in debug mode, e ok???!?!?
            //Intrebare!

            switch (parameter.ToString())
            {
                case "TownView": viewModel.SelectedViewModel = new TownViewModel(); break;
                case "LoadView": viewModel.SelectedViewModel = new LoadGameViewModel(); break;
                case "MainMenuView": viewModel.SelectedViewModel = new MainMenuViewModel(); break;
                case "CreditsView": viewModel.SelectedViewModel = new CreditsViewModel(); break;
                case "ExploreView": viewModel.SelectedViewModel = new ExploreViewModel(); break;
                case "StatsAndInventoryView": viewModel.SelectedViewModel = new StatsAndInventoryViewModel(); break;
                default: viewModel.SelectedViewModel = new MainMenuViewModel(); break;
            }
        }
    }
}
