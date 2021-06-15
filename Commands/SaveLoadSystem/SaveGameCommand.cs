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

            //Below not needed anymore as I set the player instances from the shadydealerviewmodel object deserialized - will need to fix this. 
            //var jsonText = JsonConvert.SerializeObject(PlayerInstances.CurrentPlayerInstance, jsonSettings);
            //File.WriteAllText(@"c:\Lala\CurrentPlayerInstance.json", jsonText);

            var jsonText = JsonConvert.SerializeObject(PlayerInstances.CurrentPlayerAvailableShadyDealerViewModel, jsonSettings);
            File.WriteAllText(@"c:\Lala\CurrentPlayerAvailableShadyDealerViewModel.json", jsonText);
        }
    }
}
