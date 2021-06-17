using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Maze_Knight.StaticClasses;
using Maze_Knight.Models;
using System.IO;
using Newtonsoft.Json;

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
            //Serialize Setting to keep types of properties
            JsonSerializerSettings jsonSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            //Serialize
            var jsonText = JsonConvert.SerializeObject(PlayerInstances.CurrentPlayerAvailableShadyDealerViewModel, jsonSettings);
            //Get the Path specific for the OS 
            string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CurrentPlayerAvailableShadyDealerViewModel.json");
            File.WriteAllText(destPath, jsonText);
        }
    }
}
