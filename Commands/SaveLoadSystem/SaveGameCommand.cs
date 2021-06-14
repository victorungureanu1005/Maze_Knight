using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Text.Json;
using Maze_Knight.StaticClasses;
using Maze_Knight.Models;
using System.IO;

namespace Maze_Knight.Commands.SaveLoadSystem
{
    public class SaveGameCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var jsonText = JsonSerializer.Serialize(PlayerInstances.CurrentPlayerInstance);
            File.WriteAllText(@"c:\Lala\CurrentPlayerInstance.json", jsonText);
            jsonText = JsonSerializer.Serialize(PlayerInstances.CurrentPlayerAvailableShadyDealerViewModel);
            File.WriteAllText(@"c:\Lala\CurrentPlayerAvailableShadyDealerViewModel.json", jsonText);
        }
    }
}
